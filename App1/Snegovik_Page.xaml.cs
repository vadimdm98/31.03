using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lumememm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Snegovik_Page : ContentPage
    {
        private readonly bool HideButtonClicked = true;
        private readonly bool JumpButtonClicked = true;

        public Snegovik_Page()
        {
            InitializeComponent();

            HideButton.Clicked += OnShowButtonClicked;
            ShowButton.Clicked += OnShowButtonClicked;
            ColorButton.Clicked += OnColorButtonClicked;
            MeltButton.Clicked += OnMeltButtonClicked;
            TagasiButton.Clicked += OnTagasiButtonClicked;
            JumpButton.Clicked += OnJumpButtonClicked;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        // Hide
        private void OnHideButtonClicked(object sender, EventArgs e)
        {
            Container.IsVisible = false;
        }

        // Show
        private async void OnShowButtonClicked(object sender, EventArgs e)
        {
            Container.IsVisible = true;

            Pea.BackgroundColor = Color.White;
            Kael.BackgroundColor = Color.White;
            Keha.BackgroundColor = Color.White;

            await Container.FadeTo(1, 1000, Easing.CubicIn);
            await Container.TranslateTo(0, 0, 2000, Easing.CubicOut);

            await Pea.ScaleTo(1, 1000, Easing.CubicIn);
            await Kael.ScaleTo(1, 1000, Easing.CubicIn);
            await Keha.ScaleTo(1, 1000, Easing.CubicIn);

            await Task.WhenAll(
            Pea.TranslateTo(0, 0, 1000),
            Kael.TranslateTo(0, 0, 1000),
            Keha.TranslateTo(0, 0, 1000));
        }

        // Color
        private void OnColorButtonClicked(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Color PeaColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color KaelColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color KehaColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));

            Pea.BackgroundColor = PeaColor;
            Kael.BackgroundColor = KaelColor;
            Keha.BackgroundColor = KehaColor;
        }

        // Melt
        private async void OnMeltButtonClicked(object sender, EventArgs e)
        {
            double targetY = Height + Container.Height;

            await Container.TranslateTo(0, targetY, 2000, Easing.CubicIn);
            await Container.FadeTo(0, 3000, Easing.CubicOut);

            Container.IsVisible = false;

            await Pea.ScaleTo(0, 1000);
            await Kael.ScaleTo(0, 1000, Easing.CubicOut);
            await Keha.ScaleTo(0, 1000, Easing.CubicOut);

            await Task.WhenAll(
            Pea.TranslateTo(0, 200, 2000),
            Kael.TranslateTo(0, 200, 2000),
            Keha.TranslateTo(0, 200, 2000));
        }

        // Tagasi
        private async void OnTagasiButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Jump
        private async void OnJumpButtonClicked(object sender, EventArgs e)
        {
            // Move the button up
            object p = await Container.TranslateTo(0, -20, 250, Easing.CubicOut);

            // Move the button back down
            await Container.TranslateTo(0, 0, 250, Easing.CubicIn);
        }
    }
}