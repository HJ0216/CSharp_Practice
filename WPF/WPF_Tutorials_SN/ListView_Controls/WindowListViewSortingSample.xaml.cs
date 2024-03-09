using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ListView_Controls
{
    /// <summary>
    /// Interaction logic for WindowListViewSortingSample.xaml
    /// </summary>
    public partial class WindowListViewSortingSample : Window
    {
        private GridViewColumnHeader listViewSortColumn = null;
        private SortAdorner listViewSortAdorner = null;

        public WindowListViewSortingSample()
        {
            InitializeComponent();

            List<UserB> userBs = new List<UserB>();
            userBs.Add(new UserB() { Name = "John Doe", Age = 42, Sex = SexType.Male });
            userBs.Add(new UserB() { Name = "Jane Doe", Age = 39, Sex = SexType.Female });
            userBs.Add(new UserB() { Name = "Sammy Doe", Age = 13, Sex = SexType.Male });
            userBs.Add(new UserB() { Name = "Donna Doe", Age = 13, Sex = SexType.Female });
            listViewUserBs.ItemsSource = userBs;

            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(listViewUserBs.ItemsSource);
            // 데이터 컬렉션 그룹화, 정렬, 필터링 및 탐색에 사용할 뷰
            collectionView.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
            collectionView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader columnHeader = (sender as GridViewColumnHeader);
            string sortBy = columnHeader.Tag.ToString();

            if(listViewSortColumn != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortColumn).Remove(listViewSortAdorner);
                listViewUserBs.Items.SortDescriptions.Clear();                  
            }

            ListSortDirection newDirection = ListSortDirection.Ascending;
            if(listViewSortColumn == columnHeader && listViewSortAdorner.Direction == newDirection)
            {
                newDirection = ListSortDirection.Descending;
            }

            listViewSortColumn = columnHeader;
            listViewSortAdorner = new SortAdorner(listViewSortColumn, newDirection);

            AdornerLayer.GetAdornerLayer(listViewSortColumn).Add(listViewSortAdorner);
            // AdornerLayer: UI 요소 위에 추가적인 렌더링, 비주얼 효과를 제공
            // GetAdornerLayer: listViewSortCol이라는 UI 요소를 포함하는 가장 가까운 AdornerLayer를 반환
            listViewUserBs.Items.SortDescriptions.Add(new SortDescription(sortBy, newDirection));
        }
    }

    public class UserB
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }

        public SexType Sex { get; set; }
    }

    internal class SortAdorner : Adorner
    {
        private static Geometry ascGeometry = Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");
        private static Geometry descGeometry = Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");
        /*
         M: MoveTo, 새로운 하위 경로를 시작하는 위치를 설정
         L: LineTo, 현재 위치에서 지정된 위치까지 직선을 그립니다.
         Z: ClosePath, 현재 위치에서 시작점까지 선을 그려 경로를 닫습니다.
         */

        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement adornedElement, ListSortDirection dir) : base(adornedElement)
        {
            this.Direction = dir;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if(AdornedElement.RenderSize.Width < 20)
            {
                return;
            }

            TranslateTransform translateTransform = new TranslateTransform
                (
                    AdornedElement.RenderSize.Width - 15,
                    (AdornedElement.RenderSize.Height - 5) / 2
                );

            drawingContext.PushTransform(translateTransform);

            Geometry geometry = ascGeometry;

            if(this.Direction == ListSortDirection.Descending)
            {
                geometry = descGeometry;
            }

            drawingContext.DrawGeometry(Brushes.Black, null, geometry);

            drawingContext.Pop();
        }
    }

}
