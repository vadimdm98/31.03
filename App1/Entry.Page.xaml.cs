using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Entry : ContentPage

    {

        Editor ed;
        Button btn;
        Label lbl;
        public Entry()
        {
            ed = new Editor
            {
                Placeholder = "Sisesta siia tekst",
                BackgroundColor = Color.Violet,
                TextColor = Color.Plum

            };
            lbl = new Label
            {
                Text = "Mingi tekst",
                TextColor = Color.Purple,
                BackgroundColor = Color.White,

            };

            btn = new Button
            {
                Text = "Mingi tekst",
                TextColor = Color.Blue,
                BackgroundColor = Color.Red

            };

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { ed,lbl,btn },
                BackgroundColor = Color.Pink
            };
            ed.TextChanged += Ed_TextChanged;
            lbl = new Label
            {
                Text = "Mingi Texst",
                TextColor = Color.Orange
            };
            
            
            Content = st;
            Button tagasi = new Button
            {
                Text = "Tagasi"
            };
                btn.Clicked += Tagasi_Clicked;
            
            
            




        }
        int i = 0;
        private void Ed_TextChanged(object sender, TextChangedEventArgs e)

            {   ed.TextChanged -= Ed_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

                if (key == 'A')
                {
                    i++;
                    lbl.Text = key.ToString() + ":" + i;
                }
            ed.TextChanged -= Ed_TextChanged;


        }
        private async void Tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}