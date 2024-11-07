using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlipCardApp
{
    internal class LayoutListbox : ListBox
    {
        public Layout Layout
        {
            get { return (Layout)GetValue(LayoutProperty); }
            set { SetValue(LayoutProperty, value); }
        }

        public static readonly DependencyProperty LayoutProperty =
            DependencyProperty.Register("Layout", typeof(Layout), typeof(LayoutListbox), new PropertyMetadata(Layout.List));
        // PropertyMetadata: LayoutProperty의 기본값을 Layout.List로 지정
        /**
         public static readonly DependencyProperty LayoutProperty = 
            DependencyProperty.Register(
                "Layout",                      // 속성 이름
                typeof(Layout),                // 속성 유형
                typeof(LayoutListbox),         // 소유자 유형
                new PropertyMetadata(
                    Layout.List,               // 기본값
                    OnLayoutChanged));         // 변경 알림 콜백, 속성 값이 변경될 때 UI를 업데이트하거나 추가 작업을 수행
         */
    }

    public enum Layout
    {
        Tile,
        List
    }
}
