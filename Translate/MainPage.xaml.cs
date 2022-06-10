using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Media;
using Android.Content.Res;
using Android.OS;
using MediaManager;

namespace Translate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MainPage : ContentPage
    {
        Label lb;
        Switch sw;
        BoxView box;
        Button btn,btn2;
        int i;
        int j;
        ListView list;

        Random rnd;
        Xamarin.Forms.Image img, img2;
        
        double a;
        

        public IList<string> Mp3List2 => new[]
        {"https://zvukipro.com/uploads/files/2019-04/1555493334_0b6e12ccef37d35.mp3"};
        public MainPage()

        {
            
            this.BackgroundColor = Color.White;
            lb = new Label()
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start

            };
            rnd = new Random();

            box = new BoxView()
            {
                
                Color = Color.Red,
                CornerRadius = 1000,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                
            };
            img = new Xamarin.Forms.Image()
            {

            };
            img2 = new Xamarin.Forms.Image()
            {

            };
            btn = new Button()
            {
                Text = "Salvesta progress",
                BackgroundColor = Color.LightGreen,
                HorizontalOptions = LayoutOptions.End
            };
            btn2 = new Button()
            {
                Text = "Pood",
                BackgroundColor = Color.LightGreen,

                HorizontalOptions = LayoutOptions.End
            };
           
  
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            sw.Toggled += Sw_Toggled;
            box.GestureRecognizers.Add(tap); 
            img.GestureRecognizers.Add(tap);
            img2.GestureRecognizers.Add(tap);
            btn.Clicked += Btn_Clicked;
            btn2.Clicked += Btn2_Clicked;
            StackLayout st = new StackLayout { Children = { box,img2, img, lb, btn,btn2, sw } };
            ScrollView scrollView = new ScrollView { Content = st };
            Content = st;
            Content = scrollView;
            st.Children.Add(lb);
        }

        

        async void Btn2_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Pood", "Ei osta", "Osta", "standardne pall-0", "Küpsis-50","Amogus-100","Karate-150");
            if (action == "Deatful")
            {
                box.IsVisible = true;
                img.IsVisible = false;
                img2.IsVisible = false;
            }
            else if (action == "Küpsis-50")
            {
                if (i < 50)
                {
                    string action2 = await DisplayActionSheet("Teil pole piisavalt klikke!!!", " ", "OK");
                }
                else if (i >=50)
                {
                    j = 0;
                    img.IsVisible = true;
                    box.IsVisible = false;
                    img2.IsVisible = false;
                    int a = 50;
                    i = i - a;
                    img.Source = "cookie.png";
                    string value = i.ToString();
                    Preferences.Set("Number", value);
                    lb.Text = "Сохранение " + value + " нажатий успешно!";
                }
               
                
                
            }
            else if (action == "Amogus-100")
            {
                if (i < 100)
                {
                    string action2 = await DisplayActionSheet("Teil pole piisavalt klikke!!!", "OK", "");
                }
                else if (i >= 100)
                {
                    j = 0;
                    img.IsVisible = false;
                    img2.IsVisible = true;
                    box.IsVisible = false;
                    int a = 100;
                    i = i - a;
                    img2.Source = "Amogus.png";
                    string value = i.ToString();
                    Preferences.Set("Number", value);
                    lb.Text = "Сохранение " + value + " нажатий успешно!";
                }
                

            }
            else if (action == "Karate-150")
            {
                if (i < 150)
                {
                    string action2 = await DisplayActionSheet("Teil pole piisavalt klikke!!!", "OK", "");
                }
                else if (i >= 150)
                {
                    j = 0;
                    img.IsVisible = false;
                    img2.IsVisible = true;
                    box.IsVisible = false;
                    int a = 150;
                    i = i - a;
                    img2.Source = "karate.png";
                    string value = i.ToString();
                    Preferences.Set("Number", value);
                    lb.Text = "Сохранение " + value + " нажатий успешно!";
                }


            }

        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (sw.IsToggled)
            {
                a = 0.1;
            }
            else
            {
                a = 0.01;
            }
        }

        protected override void OnAppearing()
        {
            lb.Text = Preferences.Get("Number", "ei ole sisestatud");
            i = Convert.ToInt32(lb.Text);
            lb.Text = "Загружнено: " + Preferences.Get("Number", "ei ole sisestatud") + " нажатий";
            base.OnAppearing();
        }

        public async void Btn_Clicked(object sender, EventArgs e)
        {
           
            string value = i.ToString();
            Preferences.Set("Number", value);
            lb.Text = "Сохранение " + value + " нажатий успешно!";
            
        }      


        public async void Tap_Tapped(object sender, EventArgs e)
        {

            await CrossMediaManager.Current.Play(Mp3List2);
            i++;
            j++;
            if (img.IsVisible==true && box.IsVisible == false)
            {
                
                i += 2;
                if (j == 5)
                {
                    img.Source = "cookie2.png";

                }
                else if (j == 10)
                {
                    img.IsVisible = false;
                    box.IsVisible = true;

                }
            }
            
            lb.Text = "Ты нажал " + i + " раз";
            if (i >= 1)
            {
                try
                {
                    // Use default vibration length
                    Vibration.Vibrate();
                    var duration = TimeSpan.FromSeconds(a);
                    // Or use specified time
                    Vibration.Vibrate(duration);
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Feature not supported on device
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
            
        }  
    }
}
