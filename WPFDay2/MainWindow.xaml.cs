using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDay2
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

        bool ischecked;

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(
                    txt_msg.Document.ContentStart,

                    txt_msg.Document.ContentEnd
            );
            MainViewModel viewModel =  DataContext as MainViewModel;
            if (viewModel == null)
            {
                return;
            }
            
            viewModel.Chats.Add(new ChatContent
            {
                Content = textRange.Text?.TrimEnd('\n')?.TrimEnd('\r'),
                Type = ischecked ? 2 : 1
            });

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ischecked = rd_send.IsChecked.Value;
        }

        public static string GetHeaderPic(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderPicProperty);
        }

        public static void SetHeaderPic(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderPicProperty, value);
        }

        // Using a DependencyProperty as the backing store for HeaderPic.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderPicProperty =
            DependencyProperty.RegisterAttached("HeaderPic", typeof(string), typeof(MainWindow), new PropertyMetadata(default(string)));



        public static string GetHeaderName(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderNameProperty);
        }

        public static void SetHeaderName(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for HeaderName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderNameProperty =
            DependencyProperty.RegisterAttached("HeaderName", typeof(string), typeof(MainWindow), new PropertyMetadata(default(string)));



        public static string GetLastChat(DependencyObject obj)
        {
            return (string)obj.GetValue(LastChatProperty);
        }

        public static void SetLastChat(DependencyObject obj, string value)
        {
            obj.SetValue(LastChatProperty, value);
        }

        // Using a DependencyProperty as the backing store for LastChat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastChatProperty =
            DependencyProperty.RegisterAttached("LastChat", typeof(string), typeof(MainWindow), new PropertyMetadata(default(string)));


    }

    public class ChatContent
    {
        //用户
        public string Name { get; set; }
        //类型
        public int Type { get; set; }
        //消息内容
        public object Content { get; set; }
        //日期
        public DateTime DateTime { get; set; }
        //状态
        public int Status { get; set; }
    }

    public class ChatObject
    {
        public string Name { get; set; }

        public string PicUrl { get; set; }

        public string LastContent { get; set; }
    }

    public class MainViewModel
    {
        public ObservableCollection<ChatContent> Chats { get; private set; }

       public  ObservableCollection<ChatObject> ChatList { get; private set; }

        public MainViewModel()
        {
            Init();
        }

        private void Init()
        {
            Chats = new ObservableCollection<ChatContent> {
                new ChatContent{
                 Name = "A",
                 Content ="哥哥",
                 Type = 1,
                 Status = 0
                },
                new ChatContent{
                 Name = "B",
                 Content ="啵啵",
                 Type = 2,
                 Status = 0
                }
            };

            //chats.ItemsSource = Chats;

            ChatList = new ObservableCollection<ChatObject> {
                new ChatObject{
                 Name = "苯乙烯顾问-飞飞",
                 LastContent = "看起来只能是这样",
                 PicUrl = "pack://application:,,,/WPFDay2;Component/grile.png"
                },
                new ChatObject{
                 Name = "苯乙烯顾问-白白",
                 LastContent = "看起来只能是这样",
                 PicUrl = "pack://application:,,,/WPFDay2;Component/boy.png"
                },
                new ChatObject{
                 Name = "苯乙烯顾问-红红",
                 LastContent = "看起来只能是这样",
                 PicUrl = "pack://application:,,,/WPFDay2;Component/grile.png"
                },
                new ChatObject{
                 Name = "苯乙烯顾问-等等",
                 LastContent = "看起来只能是这样",
                 PicUrl = "pack://application:,,,/WPFDay2;Component/boy.png"
                },
                new ChatObject{
                 Name = "苯乙烯顾问",
                 LastContent = "看起来只能是这样",
                 PicUrl = "pack://application:,,,/WPFDay2;Component/grile.png"
                }
            };

            //chatlst.ItemsSource = ChatList;
        }
    }
}
