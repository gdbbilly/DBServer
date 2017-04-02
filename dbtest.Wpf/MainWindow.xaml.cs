using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using dbtest.Exceptions;
using dbtest.Util;

namespace dbtest.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtName.Text = GetUser();


            var client = NewServiceClient.InstanceService();

            if (client.VotingClosed())
            {
                GridPanel1.Visibility = Visibility.Hidden;
                GridPanel2.Visibility = Visibility.Visible;

                LoadChartData();
            }
            else
            {
                GridPanel1.Visibility = Visibility.Visible;
                GridPanel2.Visibility = Visibility.Hidden;

                var voted = client.ChecksIfUserVote(GetUser());

                if (!voted)
                {
                    LoadPanelRadioBUtton(false, false);
                }
                else
                {
                    Voted(true);
                }
            }
        }

        private void LoadChartData()
        {
            var client = NewServiceClient.InstanceService();

            var list = new List<KeyValuePair<string, int>>();

            foreach (var item in client.GetRestaurantVotedToday())
            {
                list.Add(new KeyValuePair<string, int>(string.Format("{0}({1})", item.Name, item.Votes), item.Votes));
            }

            VotesChart.ItemsSource = list;
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnVote_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in PanelRadioButton.Children)
            {
                if (item.GetType() == typeof(RadioButton))
                {
                    var control = item as RadioButton;
                    if (control.IsChecked ?? false)
                    {
                        var restaurantId = Convert.ToInt32(control.Tag);

                        var client = NewServiceClient.InstanceService();
                        try
                        {
                            client.VoteInRestaurant(GetUser(), restaurantId);
                        }
                        catch (BusinessException ex)
                        {
                            MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        Voted(false);
                    }
                }
            }
        }

        private void Voted(bool initialize)
        {
            LoadPanelRadioBUtton(true, initialize);

            btnVote.Visibility = System.Windows.Visibility.Hidden;
            btnVoted.Visibility = System.Windows.Visibility.Visible;
        }

        private void LoadPanelRadioBUtton(bool voted, bool initialize)
        {
            var client = NewServiceClient.InstanceService();

            var restaurantId = client.UserVote(GetUser());

            if (voted)
            {
                if (initialize)
                {
                    foreach (var item in client.GetRestaurantsNotVotedWeek())
                    {
                        var radio = new RadioButton();
                        radio.Content = item.Name;
                        radio.Tag = item.Id;
                        radio.GroupName = "Restaurants";
                        radio.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEBEBEB"));
                        radio.IsEnabled = false;
                        if (item.Id == restaurantId)
                        {
                            radio.IsChecked = true;
                        }

                        PanelRadioButton.Children.Add(radio);
                    }
                }
                else
                {
                    foreach (var item in PanelRadioButton.Children)
                    {
                        if (item.GetType() == typeof(RadioButton))
                        {
                            var control = item as RadioButton;
                            control.IsEnabled = false;
                        }
                    }
                }
            }
            else
            {
                foreach (var item in client.GetRestaurantsNotVotedWeek())
                {
                    var radio = new RadioButton();
                    radio.Content = item.Name;
                    radio.Tag = item.Id;
                    radio.GroupName = "Restaurants";
                    radio.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEBEBEB"));

                    PanelRadioButton.Children.Add(radio);
                }
            }
        }

        private string GetUser()
        {
            return string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
        }

        private void btnOpenPortal_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:2376/");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
