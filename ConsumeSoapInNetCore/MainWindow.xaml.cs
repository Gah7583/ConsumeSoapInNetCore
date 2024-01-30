using SoapService;
using System.Windows;

namespace ConsumeSoapInNetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISoapService _soapService = new SoapServiceClient(SoapServiceClient.EndpointConfiguration.BasicHttpBinding_ISoapService_soap);
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            int number1 = Convert.ToInt32(tbNumber1.Text);
            int number2 = Convert.ToInt32(tbNumber2.Text);
            var response = await _soapService.SumAsync(new SumRequest()
            {
                Body = new SumRequestBody()
                {
                    num1 = number1,
                    num2 = number2
                }
            });
            lblResponse.Content = response.Body.SumResult;
        }
    }
}