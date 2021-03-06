﻿using Microsoft.Win32;
using SOD_CS_Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region SOD.config set up
        //ConfigFile reader instance
        ConfigurationFileReader configreader;

        // Device parameters
        int _deviceID;
        string _deviceName;
        string _observerType;
        bool _deviceIsStationary;
        double _deviceWidthInMM
                , _deviceHeightInMM
                , _deviceLocationX
                , _deviceLocationY
                , _deviceLocationZ
                , _deviceOrientation
                , _deviceFOV
                , _deviceObservableRange;
        // SOD parameters
        string _sodAddress;
        int _sodPort;


        // Device perimeter - used to tell if someone is close or far from the device.

        private SOD SoD;
        private string _deviceType;
        #endregion

        #region Image Specific

        static TouchPoint touchStart;
            static bool isAlreadySwiped=false;
            static Dictionary<String,String> DictionaryOfImagesReceived= new Dictionary<String,String>();
            static int marginX=20;
            static int marginY=20;
            // Identified People
            //static List<PersonPairing> _IdentifiedPeople = new List<PersonPairing>();
            // Enter and Leave Values


            private string ImageToBase64(System.Drawing.Image img, System.Drawing.Imaging.ImageFormat format)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    img.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
                throw new NotImplementedException();
            }
        #endregion


            public MainWindow()
            {
                InitializeComponent();
                // SoD configuration with ip and port and Device configuration (type, dimensions, location, orientation...)
                DefineSettings();
                ConfigureSoD();
                ConfigureDevice();
                // Routes definition
                RegisterSoDEvents();
                Thread checkForDevicesInView = new Thread(() => getDevicesInView());
                checkForDevicesInView.Start();
            }
            /// <summary>
            /// Region SoD contains SoD Configuration, Device Configuration, Definition of Routes and their handlers (e.g. sending notes)
            /// </summary>


            # region SoD
            private void ConfigureSoD()
            {
                // Customizations are made on the variables defined up up up away!
                // Don't change this unless you know what you're doing.

                // Configure and instantiate SOD object
                string address = _sodAddress;
                int port = _sodPort;
                SoD = new SOD(address, port);

                // Configure device with its dimensions (mm), location in physical space (X, Y, Z in meters, from sensor), orientation (degrees), Field Of View (FOV. degrees) and name
                SoD.ownDevice.SetDeviceInformation(_deviceWidthInMM, _deviceHeightInMM, _deviceLocationX, _deviceLocationY, _deviceLocationZ, _deviceType, _deviceIsStationary);
                SoD.ownDevice.orientation = _deviceOrientation;
                SoD.ownDevice.FOV = _deviceFOV;
                SoD.ownDevice.observer.observeRange = _deviceObservableRange;
                SoD.ownDevice.stationary = false;

                SoD.ownDevice.ID = _deviceID;
                SoD.ownDevice.name = _deviceName;
            }

            private void DefineSettings()
            {
                configreader = new ConfigurationFileReader();

                // Device parameters
                this._deviceWidthInMM = configreader.ConvertStringToDouble("widthInMM");
                this._deviceHeightInMM = configreader.ConvertStringToDouble("heightInMM");
                this._deviceLocationX = configreader.ConvertStringToDouble("locationX");
                this._deviceLocationY = configreader.ConvertStringToDouble("locationY");
                this._deviceLocationZ = configreader.ConvertStringToDouble("locationZ");
                this._deviceOrientation = configreader.ConvertStringToDouble("orientation");
                this._deviceFOV = configreader.ConvertStringToDouble("fieldOfView");
                this._deviceID = (int)configreader.ConvertStringToDouble("_deviceID");
                this._deviceName = configreader.GetConfigSettings("_deviceName");
                this._deviceIsStationary = configreader.ConvertStringToBool("_deviceIsStationary");
                this._observerType = configreader.GetConfigSettings("_observerType");
                this._deviceObservableRange = configreader.ConvertStringToDouble("observableRange");
                this._deviceType = configreader.GetConfigSettings("_deviceType");

                this._sodAddress = configreader.GetConfigSettings("address");
                this._sodPort = (int)configreader.ConvertStringToDouble("port");
            }

            private void ConfigureDevice()
            {
                // Configure device with its dimensions (mm), location in physical space (X, Y, Z in meters, from sensor), orientation (degrees), Field Of View (FOV. degrees) and name
                SoD.ownDevice.SetDeviceInformation(_deviceWidthInMM, _deviceHeightInMM, _deviceLocationX, _deviceLocationY, _deviceLocationZ, _deviceType, _deviceIsStationary);
                SoD.ownDevice.orientation = _deviceOrientation;
                SoD.ownDevice.FOV = _deviceFOV;

                SoD.ownDevice.stationary = false;
                // Name and ID of device - displayed in Locator
                SoD.ownDevice.ID = _deviceID;
                SoD.ownDevice.name = _deviceName;
            }

            private void RegisterSoDEvents()
            {
                // register for 'connect' event with io server
                SoD.On("connect", (data) =>
                {
                    Console.WriteLine("\r\nConnected...");
                    Console.WriteLine("Registering with server...\r\n");
                    SoD.RegisterDevice();  //register the device with server every time it connects or re-connects
                });

                SoD.On("request", (data) =>
                {
                    Console.WriteLine("Received request: " + data);
                });

                SoD.On("requestedData", (dict) =>
                {
                    Newtonsoft.Json.Linq.JObject o = dict.data;
                    for (int i = 1; i <= o.Count; i++)
                    {
                        DictionaryOfImagesReceived.Add(i.ToString(), (string)dict.data[i.ToString()]);
                    }
                    ProcessDictionary();
                });

                // make the socket.io connection
                SoD.SocketConnect();
            }

            # endregion

            private void SendPicture()
            {
                String fileLocation = txtBrowse.Text; 
                System.Drawing.Image img = System.Drawing.Image.FromFile(fileLocation);
                String strToSend = ImageToBase64(img, img.RawFormat);
                //SoD.SendStringToDevices(strToSend, selection);
                SoD.SendToDevices.InView("string", strToSend);
            }

            private void getDevicesInView()
            {
                while(true){
                    SoD.GetDevicesWithSelection("inView",updateDeviceInView);
                    System.Threading.Thread.Sleep(1);
                }
            }

            private void updateDeviceInView(List<Device> devices)
            {
                if (devices.Count == 0)
                {
                    txtBoardInView.Content = "";
                    return;
                }
                else
                {
                    txtBoardInView.Content = "I see something";
                }
            }

            private void ProcessDictionary() 
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    foreach (var element in DictionaryOfImagesReceived)
                    {
                        Image imgTransmission = new Image();
                        imgTransmission.Source = ConvertDrawingImageToWPFImage(Base64ToImage(element.Value)).Source;
                        imgTransmission.Height = 100;
                        imgTransmission.Width = 100;
                        imgCanvas.Children.Add(imgTransmission);
                        imgTransmission.Margin = new Thickness(marginX, marginY, 0, 0);
                        if ((marginX + 2 * imgTransmission.Width) > imgCanvas.ActualWidth)
                        {
                            marginY += (int)(1.5 * imgTransmission.Width);
                            marginX = 20;
                        }
                        else
                        {
                            marginX += 150;
                        }
                    }
                }));
            }
            private void Grid_TouchDown(object sender, TouchEventArgs e)
            {
                touchStart = e.GetTouchPoint(this);
            }

            private void Grid_TouchMove(object sender, TouchEventArgs e)
            {
                if (!isAlreadySwiped)
                {
                    var nextPoint = e.GetTouchPoint(this);
                    if (touchStart != null && nextPoint.Position.Y < (touchStart.Position.Y-20))
                    {
                        SendPicture();
                        isAlreadySwiped = true;
                    }
                }
            }
        
            private void FileTextChanged(object sender, TextChangedEventArgs e)
            {
                //imgToSend.Source = System.Windows.Media.ImageSource(e.ToString);
            }

            private void Browse_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Multiselect = false;

                open.Filter = "AllFiles|*.*";

                if ((bool)open.ShowDialog())
                {
                    txtBrowse.Text=open.FileName;
                    imgToSend.Source = new BitmapImage(new Uri(open.FileName));
                    isAlreadySwiped = false;
                }
                else
                {
                    txtBrowse.Text = " No files selected!";
                }
            }

            private void GetImages_Click(object sender, RoutedEventArgs e)
            {
                // CANT gET THE SAMPLE CLIENT CODE TO WORK
                String strToSend = "GetImages";
              //  SoD.SendStringToDevices(strToSend, selection);
                SoD.SendToDevices.InView("string",strToSend);
            }

            public System.Drawing.Image Base64ToImage(string base64String)
            {
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                return image;
            }


            public System.Windows.Controls.Image ConvertDrawingImageToWPFImage(System.Drawing.Image gdiImg)
            {
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();

                //convert System.Drawing.Image to WPF image
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(gdiImg);
                IntPtr hBitmap = bmp.GetHbitmap();
                System.Windows.Media.ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                img.Source = WpfBitmap;
                img.Width = 500;
                img.Height = 600;
                img.Stretch = System.Windows.Media.Stretch.Fill;
                return img;
            }

            private void Calibration_Button_Click(object sender, RoutedEventArgs e)
            {
                SoD.CalibrateOrientation();
                CalibrateButton.Visibility = System.Windows.Visibility.Hidden;
                SendOrientationButton.Visibility = System.Windows.Visibility.Visible;
            }

            private void Send_Orientation_Button_Click(object sender, RoutedEventArgs e)
            {
                SoD.StartSendingOrientation(200);
                SoD.StopSendingOrientation();
                CalibrateButton.Visibility = System.Windows.Visibility.Visible;
                SendOrientationButton.Visibility = System.Windows.Visibility.Hidden;
            }



            Point currentPoint = new Point(0, 0);
            private SolidColorBrush _selectedColor = Brushes.Black;

            private void _drawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
            {
                currentPoint = e.GetPosition(_drawingCanvas);
            }

            private void _drawingCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Line line = new Line();
                    line.StrokeThickness = this._brushSlider.Value;
                    line.Stroke = _selectedColor;
                    line.X1 = currentPoint.X;
                    line.Y1 = currentPoint.Y;
                    line.X2 = e.GetPosition(_drawingCanvas).X;
                    line.Y2 = e.GetPosition(_drawingCanvas).Y;

                    currentPoint = e.GetPosition(_drawingCanvas);

                    _drawingCanvas.Children.Add(line);
                }
                else
                {
                    currentPoint = e.GetPosition(_drawingCanvas);
                }
            }

            public void ExportToPng(Uri path, Canvas surface)
            {
                if (path == null) return;

                // Save current canvas transform
                Transform transform = surface.LayoutTransform;
                // reset current transform (in case it is scaled or rotated)
                surface.LayoutTransform = null;

                // Get the size of canvas
                Size size = new Size(surface.Width, surface.Height);
                // Measure and arrange the surface
                // VERY IMPORTANT
                surface.Measure(size);
                surface.Arrange(new Rect(size));

                // Create a render bitmap and push the surface to it
                RenderTargetBitmap renderBitmap =
                  new RenderTargetBitmap(
                    (int)size.Width,
                    (int)size.Height,
                    96d,
                    96d,
                    PixelFormats.Pbgra32);
                renderBitmap.Render(surface);

                // Create a file stream for saving image
                using (FileStream outStream = new FileStream(path.LocalPath, FileMode.Create))
                {
                    // Use png encoder for our data
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    // push the rendered bitmap to it
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    // save the data to the stream
                    encoder.Save(outStream);
                }

                // Restore previously saved layout
                surface.LayoutTransform = transform;
            }


            #region Color Palette Event Handlers

            private void OnBlackSelect(object sender, MouseButtonEventArgs e)
            {
                this._selectedColor = (SolidColorBrush)this._blackPalette.Fill;
            }

            private void OnCrimsonSelect(object sender, MouseButtonEventArgs e)
            {
                this._selectedColor = (SolidColorBrush)this._redPalette.Fill;
            }

            private void OnBlueSelect(object sender, MouseButtonEventArgs e)
            {
                this._selectedColor = (SolidColorBrush)this._bluePalette.Fill;
            }

            private void OnPinkSelect(object sender, MouseButtonEventArgs e)
            {
                this._selectedColor = (SolidColorBrush)this._pinkPalette.Fill;
            }

            #endregion

            private void _clearButton_Click(object sender, RoutedEventArgs e)
            {
                this._drawingCanvas.Children.Clear();
            }

            private void CreateFile_Click(object sender, RoutedEventArgs e)
            {
                ExportToPng(new Uri(@"C:\ODTabletLogs\test.png"), _drawingCanvas);
            }





       
    }
}
