using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForSafePicture
{
    public partial class MainPage : ContentPage
    {
        public string pathName;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            imgList.ItemsSource = App.DB.GetAll();
            base.OnAppearing();
        }

        void UpdateList()
        {
            imgList.ItemsSource = App.DB.GetAll();
        }

        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                Debug.WriteLine($"Путь фото {photo.FullPath}");

                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private void BtnAddImage_Clicked(object sender, EventArgs e)
        {
            CustomItem ci = new CustomItem();
            ci.Name = ImageName.Text;
            ci.ImagePath = pathName;
            App.DB.SaveNew(ci);
            UpdateList();
        }

        private async void imgList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CustomItem selectedImage = (CustomItem)e.SelectedItem;
            OpenedItemPage imagePage = new OpenedItemPage();
            imagePage.BindingContext = selectedImage;
            await Navigation.PushAsync(imagePage);
        }
    }
}
