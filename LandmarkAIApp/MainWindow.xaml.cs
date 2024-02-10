using LandmarkAIApp.Classes;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LandmarkAIApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image files(*.png; *.jpg)|*.png;*.jpg;*.jpeg|All files(*.*)|*.*";
            // Filter에 표시될 이름|실제로 필터링할 파일 형식
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // dialog 초기 Directory 설정

            if(dialog.ShowDialog() == true)
            // 사용자가 "열기" 버튼을 클릭하면 ShowDialog() 메서드는 true를 반환하고,
            // 사용자가 "취소" 버튼을 클릭하거나 대화 상자를 닫으면 false를 반환
            {
                string fileName = dialog.FileName;
                // 파일 경로를 포함한 파일 이름

                selectedImage.Source = new BitmapImage(new Uri(fileName));

                MakePredictionAsync(fileName);
            }
        }

        private async void MakePredictionAsync(string fileName)
        {
            string url = "Prediction_API_URL";
            string prediction_Key = "Prediction_API_KEY";
            string content_type = "application/octet-stream";
            var file = File.ReadAllBytes(fileName);

            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", prediction_Key);
                // 헤더에 Prediction-Key 추가

                using (var content = new ByteArrayContent(file))
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(content_type);
                    // 기본 Header인 Content-Type 사용
                    var response = await client.PostAsync(url, content);

                    string responseString = await response.Content.ReadAsStringAsync();

                    List<Prediction> predictions = (JsonConvert.DeserializeObject<CustomVision>(responseString)).Predictions;
                    // JSON 문자열 responseString을 CustomVision 타입의 객체로 변환(역직렬화)

                    predictionsListView.ItemsSource = predictions;
                }
            }
        }
    }
}