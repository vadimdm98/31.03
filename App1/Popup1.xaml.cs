using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup1 : ContentPage
    {
        public Popup1()
        {
            Button alertButton = new Button
            {
                Text = "Teade",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
            };
            alertButton.Clicked += alertButton_Clicked;
            Button alertYesButton = new Button
            {
                Text = "Jah või ei",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center

            };
            alertYesButton.Clicked += AlertYesButton_Clicked;
            Button alertListButton = new Button
            {
                Text = "Valik",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertListButton.Clicked += AlertListButton_Clicked;
            Content = new StackLayout { Children = { alertButton, alertYesButton, alertListButton } };
            Button alertQuestButton = new Button
            {
                Text ="Küsimus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
            };
            alertQuestButton.Clicked += AlertQuestButton_Clicked;
            Content= new StackLayout { Children = {alertButton, alertYesButton, alertListButton} };
        }

        private async void AlertQuestButton_Clicked(object sender, EventArgs e)
        {
            string result1 = await DisplayPromptAsync("Küsimus", "Kuidas läheb?", placeholder: "Tore!");
            string result2 = await DisplayPromptAsync("Vasta","Millega võrdub 5 + 5?", initialValue:"10",maxLength:2, keyboard: Keyboard.Numeric);
        }

        private async void AlertListButton_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Mida teha?", "Loobu", "kistutada", "Tantsida","Laulda","Joonestada");
        }

        private async void AlertYesButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Kinnitus", "Kas oled kindel", "Olen kindel", "Ei ole lindel");
            await DisplayAlert("Teade", "Teie valik on: " + (result ? "Jah" : "Ei"), "ok");
        }

        private void alertButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Teade", "Teil on uus teade", "ok");
        }
       
        
    }
}