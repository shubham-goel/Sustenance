using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sustenance_V_1._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        ////===========CONVERTERS==========//
        //public class species_chart_itemsource_converter : IValueConverter
        //{
        //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //    {
        //        var sp = parameter as species;
        //        List<Population> data = new List<Population>();
        //        data.Add(new Population() { Name = "Healthy", Amount = sp.healthy });
        //        data.Add(new Population() { Name = "Healthy", Amount = sp.sick });
        //        return data;
        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //    {
        //        return true;
        //    }
        //}

//===========VAR DEFINITIONS===========//
        List<species> all_species = new List<species>();

        species Aquatic_Plants = new species() { name = "Aquatic_Plants"};
        species Bee = new species() { name = "Bee" };
        species Cow = new species() { name = "Cow" };
        species Deer = new species() { name = "Deer" };
        species Eagle = new species() { name = "Eagle" };
        species Elephant = new species() { name = "Elephant" };
        species Fruits = new species() { name = "Fruits" };
        species Goat = new species() { name = "Goat" };
        species Grass_Flowers = new species() { name = "Grass_Flowers" };
        species Grasshopper = new species() { name = "Grasshopper" };
        species Lion = new species() { name = "Lion" };
        species Monkey = new species() { name = "Monkey" };
        species Rabbit = new species() { name = "Rabbit" };
        species Shark = new species() { name = "Shark" };
        species Sheep = new species() { name = "Sheep" };
        species Small_Bird = new species() { name = "Small_Bird" };
        species Small_Fish = new species() { name = "Small_Fish" };
        species Vulture = new species() { name = "Vulture" };

        

        //public List<double> double_list(double a, double b)
        //{
        //    List<double> data = new List<double>();
        //    data.Add(a);
        //    data.Add(b);
        //    return data;
        //} 

        //public object find(List<species> list, string sp_name)
        //{
            
        //}

        //public void add_species(List<species> list)
        //{
        //    all_species.Add(new species() { name = "Aquatic_Plants", sick_b = Aquatic_Plants_s, healthy_b = Aquatic_Plants_h, title = Aquatic_Plants_n, healthy = 100, sick = 0, grid = Aquatic_Plants, image = Aquatic_Plants_i, circle = Aquatic_Plants_e, chart = Aquatic_Plants_Chart });
        //    all_species.Add(new species() { name = "Small_Fish", sick_b = Small_Fish_s, healthy_b = Small_Fish_h, title = Small_Fish_n, healthy = 100, sick = 0, grid = Small_Fish, image = Small_Fish_i, circle = Small_Fish_e, chart = Small_Fish_Chart });
        //    all_species.Add(new species() { name = "Grasshopper", sick_b = Grasshopper_s, healthy_b = Grasshopper_h, title = Grasshopper_n, healthy = 100, sick = 0, grid = Grasshopper, image = Grasshopper_i, circle = Grasshopper_e, chart = Grasshopper_Chart });
        //    all_species.Add(new species() { name = "Rabbit", sick_b = Rabbit_s, healthy_b = Rabbit_h, title = Rabbit_n, healthy = 100, sick = 0, grid = Rabbit, image = Rabbit_i, circle = Rabbit_e, chart = Rabbit_Chart });
        //    all_species.Add(new species() { name = "Sheep", sick_b = Sheep_s, healthy_b = Sheep_h, title = Sheep_n, healthy = 100, sick = 0, grid = Sheep, image = Sheep_i, circle = Sheep_e, chart = Sheep_Chart });
        //    all_species.Add(new species() { name = "Bee", sick_b = Bee_s, healthy_b = Bee_h, title = Bee_n, healthy = 100, sick = 0, grid = Bee, image = Bee_i, circle = Bee_e, chart = Bee_Chart });
        //    all_species.Add(new species() { name = "Small_Bird", sick_b = Small_Bird_s, healthy_b = Small_Bird_h, title = Small_Bird_n, healthy = 100, sick = 0, grid = Small_Bird, image = Small_Bird_i, circle = Small_Bird_e, chart = Small_Bird_Chart });
        //    all_species.Add(new species() { name = "Deer", sick_b = Deer_s, healthy_b = Deer_h, title = Deer_n, healthy = 100, sick = 0, grid = Deer, image = Deer_i, circle = Deer_e, chart = Deer_Chart });
        //    all_species.Add(new species() { name = "Eagle", sick_b = Eagle_s, healthy_b = Eagle_h, title = Eagle_n, healthy = 100, sick = 0, grid = Eagle, image = Eagle_i, circle = Eagle_e, chart = Eagle_Chart });
        //    all_species.Add(new species() { name = "Fruits", sick_b = Fruits_s, healthy_b = Fruits_h, title = Fruits_n, healthy = 100, sick = 0, grid = Fruits, image = Fruits_i, circle = Fruits_e, chart = Fruits_Chart });
        //    all_species.Add(new species() { name = "Goat", sick_b = Goat_s, healthy_b = Goat_h, title = Goat_n, healthy = 100, sick = 0, grid = Goat, image = Goat_i, circle = Goat_e, chart = Goat_Chart });
        //    all_species.Add(new species() { name = "Grass_Flowers", sick_b = Grass_Flowers_s, healthy_b = Grass_Flowers_h, title = Grass_Flowers_n, healthy = 100, sick = 0, grid = Grass_Flowers, image = Grass_Flowers_i, circle = Grass_Flowers_e, chart = Grass_Flowers_Chart });
        //    all_species.Add(new species() { name = "Lion", sick_b = Lion_s, healthy_b = Lion_h, title = Lion_n, healthy = 100, sick = 0, grid = Lion, image = Lion_i, circle = Lion_e, chart = Lion_Chart });
        //    all_species.Add(new species() { name = "Elephant", sick_b = Elephant_s, healthy_b = Elephant_h, title = Elephant_n, healthy = 100, sick = 0, grid = Elephant, image = Elephant_i, circle = Elephant_e, chart = Elephant_Chart });
        //    all_species.Add(new species() { name = "Vulture", sick_b = Vulture_s, healthy_b = Vulture_h, title = Vulture_n, healthy = 100, sick = 0, grid = Vulture, image = Vulture_i, circle = Vulture_e, chart = Vulture_Chart });
        //    all_species.Add(new species() { name = "Monkey", sick_b = Monkey_s, healthy_b = Monkey_h, title = Monkey_n, healthy = 100, sick = 0, grid = Monkey, image = Monkey_i, circle = Monkey_e, chart = Monkey_Chart });
        //    all_species.Add(new species() { name = "Shark", sick_b = Shark_s, healthy_b = Shark_h, title = Shark_n, healthy = 100, sick = 0, grid = Shark, image = Shark_i, circle = Shark_e, chart = Shark_Chart });
        //    all_species.Add(new species() { name = "Cow", sick_b = Cow_s, healthy_b = Cow_h, title = Cow_n, healthy = 100, sick = 0, grid = Cow, image = Cow_i, circle = Cow_e, chart = Cow_Chart });
        //}

        public MainPage()
        {
            this.InitializeComponent();

            add_species(all_species);
            link_members(all_species);
            LoadChartContents(all_species);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

//=========ON CLICK FUNCTIONS==========//
        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            
            LoadChartContents(all_species);
        }
        private void test_Click(object sender, RoutedEventArgs e)
        {
            myFlyout.ShowAt(page);
        }
        private void Species_Grid_Clicked(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)//sender =Grid
        {
            // TODO: Add event handler implementation here.

            species sp = all_species.Find(x => (x.name + "_g") == object_to_name(sender));

            myFlyout_Title.Text = sp.name;
            myFlyout_sc_name.Text = "Sc Name: " + sp.sc_name + " ";
            myFlyout_desc.Text = "DESCRIPTION" + '\n' + '\n' + sp.desc;
            //myFlyout_wiki.NavigateUri = "http://wiki.com" ;
            myFlyout.ShowAt(sp.grid);
            sp.title.Visibility = Visibility.Collapsed;
        }
       
        
//===========HOVER START FUNCTIONS==========//
        private void test_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            test.Opacity = 0.5;
        }
        private void Species_Grid_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)//sender =Grid
        {
            // TODO: Add event handler implementation here.

            species sp = all_species.Find(x => (x.name + "_g") == object_to_name(sender));

            scale_transform(sp.grid, 1.1, 1.1);

            //SHOW title, population values
            sp.sick_b.Visibility = Visibility.Visible;
            sp.healthy_b.Visibility = Visibility.Visible;
            sp.title.Visibility = Visibility.Visible;
            
        }


//===========HOVER END FUNCTIONS==========//
        private void Species_Grid_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)//sender = Grid
        {
            // TODO: Add event handler implementation here.

            species sp = all_species.Find(x => (x.name + "_g") == object_to_name(sender));

            scale_transform(sp.grid, 1, 1);

            //HIDE title, population values
            sp.sick_b.Visibility = Visibility.Collapsed;
            sp.healthy_b.Visibility = Visibility.Collapsed;
            sp.title.Visibility = Visibility.Collapsed;
        }

//===========UTILITY FUNCTIONS==========//
        public void scale_transform(UIElement element, double x, double y)
        {
            element.RenderTransformOrigin = new Point(0.5, 0.5);

            ScaleTransform myScaleTransform = new ScaleTransform();
            myScaleTransform.ScaleY = x;
            myScaleTransform.ScaleX = y;
            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myScaleTransform);
            element.RenderTransform = myTransformGroup; 
        }
        public string object_to_name(object sender)
        {
            var spec = sender as Grid;
            var species_name = spec.Name;
            string sp_name = species_name.ToString();
            return sp_name;
        }
        private void LoadChartContents(List<species> list)
        {
            Random rand = new Random();
            foreach (species mySpecies in list)
            {


                ///================Updeate healthy and sick values======================///

                mySpecies.healthy = rand.Next(0, 200);
                mySpecies.sick = rand.Next(0, 200);

                ///=====================================================================///

                mySpecies.update_population_boxes();
                mySpecies.update_chart();
            }

        }
        public void link_members(species sp)
        {
            sp.grid = FindName(sp.name + "_g") as Grid;
            sp.image = FindName(sp.name + "_i") as Image;
            sp.sick_b = FindName(sp.name + "_s") as TextBlock;
            sp.healthy_b = FindName(sp.name + "_h") as TextBlock;
            sp.title = FindName(sp.name + "_n") as TextBox;
            sp.circle = FindName(sp.name + "_e") as Ellipse;
            sp.chart = FindName(sp.name + "_Chart") as Chart;
        }
        public void link_members(List<species> list)
        {
            foreach (species sp in list)
            {
                link_members(sp);
            }
        }
        public void add_species(List<species> list)
        {

            all_species.Add(Aquatic_Plants);
            all_species.Add(Bee);
            all_species.Add(Cow);
            all_species.Add(Deer);
            all_species.Add(Eagle);
            all_species.Add(Elephant);
            all_species.Add(Fruits);
            all_species.Add(Goat);
            all_species.Add(Grass_Flowers);
            all_species.Add(Grasshopper);
            all_species.Add(Lion);
            all_species.Add(Monkey);
            all_species.Add(Rabbit);
            all_species.Add(Shark);
            all_species.Add(Sheep);
            all_species.Add(Small_Bird);
            all_species.Add(Small_Fish);
            all_species.Add(Vulture);
        }


    }

    //===========CLASS DEFINITIONS===========//
    public class species
    {
        public string name { get; set; }
        public double healthy { get; set; }
        public double sick { get; set; }
        public string sc_name { get; set; }
        public string desc { get; set; }
        public string wiki { get; set; }
        public Grid grid { get; set; }
        public Image image { get; set; }
        public Ellipse circle { get; set; }
        public Chart chart { get; set; }
        public TextBlock sick_b { get; set; }
        public TextBlock healthy_b { get; set; }
        public TextBox title { get; set; }


        public void update_chart()
        {
            //(chart.Series[0] as PieSeries).ItemsSource = double_list(healthy, sick);
            List<Population> data = new List<Population>();
            data.Add(new Population() { Name = "Healthy", Amount = healthy });
            data.Add(new Population() { Name = "Healthy", Amount = sick });
            (chart.Series[0] as PieSeries).ItemsSource = data;
        }
        public void update_population_boxes()
        {
            healthy_b.Text = healthy.ToString();
            sick_b.Text = sick.ToString();
        }

        public species()
        {

        }

    }

    public class Population
    {
        public string Name { get; set; }
        public double Amount { get; set; }
    }

}
