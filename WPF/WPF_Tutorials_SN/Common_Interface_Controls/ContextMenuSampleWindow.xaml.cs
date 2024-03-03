using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Common_Interface_Controls
{
    /// <summary>
    /// Interaction logic for ContextMenuSampleWindow.xaml
    /// </summary>
    public partial class ContextMenuSampleWindow : Window
    {
        public ContextMenuSampleWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = this.FindResource("cmButton") as ContextMenu;
            // FindResource("buttonContextMenu") 
            // FindResource 메소드는 XAML 리소스 사전에서 지정된 키에 해당하는 리소스를 찾음
            contextMenu.PlacementTarget = imHere as Label;
            // ContextMenuService.Placement="Bottom" 추가 설정 필요
            // contextMenu.PlacementTarget = imHere as Label;은 비하인드 코드에서 필수적으로 적어야 함
            // ContextMenuService.PlacementTarget="{Binding ElementName=imHere}"와 같은 바인딩은 imHere 요소가 ContextMenu와 같은 비주얼 트리에서 찾을 수 없다면 동작하지 않습니다.
            // ContextMenu는 비주얼 트리의 일부가 아니므로, 일반적인 바인딩(Binding) 방식이 동작하지 않을 수 있음
            contextMenu.IsOpen = true;
            // 컨텍스트 메뉴는 즉시 열리며 이 때 PlacementTarget의 위치에 상관없이 현재 마우스 위치에 표시
        }

    }
}
