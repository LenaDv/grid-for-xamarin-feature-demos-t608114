using DevExpress.Mobile.DataGrid;
using DevExpress.Mobile.DataGrid.Internal;
using DevExpress.Mobile.DataGrid.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevExpress.GridDemo {
    public partial class GroupPage {
        public GroupPage() {
            //ThemeManager.Theme.GroupCustomizer = new MyGroupCustomizer();
            InitializeComponent();
            BindData();
            //grid.AllowGroupCollapse = false;
        }
        async void BindData() {
            BindingContext = await LoadData();
        }
        Task<MainPageViewModel> LoadData() {
            return Task<MainPageViewModel>.Run(() => new MainPageViewModel(new DemoOrdersRepository()));
        }
    }


    public class MyGroupCustomizer : DarkGroupCustomizer {
        public override void LocateViewInRow(View view, Rectangle cellBounds) {
            base.LocateViewInRow(view, cellBounds);

            SimplyCellView scv = view as SimplyCellView;
            if (scv == null)
                return;

            scv.InputTransparent = false;

            Grid gridContent = scv.Content as Grid;
            if ((gridContent == null) || (gridContent.Children.Count < 2))
                return;

            Label groupTextLabel = gridContent.Children[1] as Label;
            if ((groupTextLabel == null) || string.IsNullOrEmpty(groupTextLabel.Text))
                return;


            string[] groupTextParts = groupTextLabel.Text.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
            if (groupTextParts.Length != 2)
                return;

            string fieldName = groupTextParts[0]; // Your field name
            string fieldValue = groupTextParts[1]; // Value of this row

            ScrollAreaView parentView = view.Parent as ScrollAreaView;
            parentView.InputTransparent = false;

            Button b = new Button() { Text = "Tap Me" };
            b.Clicked += Tap;
            parentView.Children.Add(b);
            b.Layout(new Rectangle() { X = 150, Y = 5, Width = 200, Height = 50 });
        }

        void Tap(object sender, EventArgs e) {
            ;
        }
    }
}
