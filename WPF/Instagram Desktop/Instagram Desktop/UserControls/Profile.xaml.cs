﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Instagram_Desktop.UserControls
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PaddingNumProperty = DependencyProperty.Register("PaddingNum", typeof(int), typeof(Profile));
        public int PaddingNum
        {
            get { return (int)GetValue(PaddingNumProperty); }
            set { SetValue(PaddingNumProperty, value); }
        }

        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(int), typeof(Profile));
        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // 의존성 속성(Dependency Property) 정의
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(Profile)); // DependencyProperty.Register(속성 이름, 속성 타입, 소유하는 클래스 타입)
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

    }
}
