using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Valgusfoor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Valgusfoor : ContentPage
    {
        private bool ButtonSisseClicked = false;
        private bool ButtonVäljaClicked = false;

        public Valgusfoor()
        {
            InitializeComponent();

            redFrame.BackgroundColor = Color.Black;
            yellowFrame.BackgroundColor = Color.Black;
            greenFrame.BackgroundColor = Color.Black;

            redFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("1", "2", "3");
                        return;
                    }
                    redFrame.BackgroundColor = Color.Red;
                    redLabel.Text = "Stop!";
                    redLabel.FontSize = 10;
                    redLabel.TextColor = Color.Black;
                })
            });

            yellowFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("1", "2", "3");
                        return;
                    }
                    yellowFrame.BackgroundColor = Color.Yellow;
                    yellowLabel.Text = "Wait";
                    yellowLabel.FontSize = 10;
                    yellowLabel.TextColor = Color.Black;
                })
            });

            greenFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("1", "2", "3");
                        return;
                    }
                    greenFrame.BackgroundColor = Color.Green;
                    greenLabel.Text = "Ok!";
                    greenLabel.FontSize = 10;
                    greenLabel.TextColor = Color.Black;
                })
            });

            ButtonSisse.Clicked += OnButtonSisseClicked;

            ButtonVälja.Clicked += OnButtonVäljaClicked;

            ButtonTagasi.Clicked += OnButtonTagasiClicked;
        }

        private async void OnButtonTagasiClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnButtonSisseClicked(object sender, EventArgs e)
        {
            ButtonSisseClicked = true;

            redFrame.BackgroundColor = Color.Red;
            yellowFrame.BackgroundColor = Color.Yellow;
            greenFrame.BackgroundColor = Color.Green;
        }

        private void OnButtonVäljaClicked(object sender, EventArgs e)
        {
            ButtonVäljaClicked = true;

            Device.BeginInvokeOnMainThread(async () =>
            {
                bool answer = await DisplayAlert("Foori väljalülitamine", "Kas tahaksite foori välja lülitada?", "Jah", "Ei");

                if (answer == true)
                {
                    ButtonSisseClicked = false;

                    ButtonSisse.BackgroundColor = Color.Black;

                    redFrame.BackgroundColor = Color.Black;
                    yellowFrame.BackgroundColor = Color.Black;
                    greenFrame.BackgroundColor = Color.Black;

                                      
                }
                else
                {
                    ButtonVäljaClicked = false;
                    ButtonSisseClicked = true;

                }
            });
        }
    }
}