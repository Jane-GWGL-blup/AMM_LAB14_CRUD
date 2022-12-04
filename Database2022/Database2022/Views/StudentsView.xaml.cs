using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database2022.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Database2022.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsView : ContentPage
    {
        public StudentsView()
        {
            InitializeComponent();
            this.BindingContext = new ViewModelStudents();
        }
    }
}