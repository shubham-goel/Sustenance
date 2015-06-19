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
using Windows.UI.Xaml.Media.Animation;
using System.ComponentModel;
//using System.Windows.Threading;
//using System.Windows.DragDrop;


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
        List<Environment_species> all_env = new List<Environment_species>();
        List<Industrial_species> all_ind = new List<Industrial_species>();

        List<potion> all_pot_animals = new List<potion>();
        List<potion_infi> all_pot_infi = new List<potion_infi>();

        species Aquatic_Plants = new species() { name = "Aquatic_Plants", wiki = "http://www.google.co.in", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Bee = new species() { name = "Bee", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Cow = new species() { name = "Cow", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Deer = new species() { name = "Deer", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Eagle = new species() { name = "Eagle", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Elephant = new species() { name = "Elephant", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Fruits = new species() { name = "Fruits", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Goat = new species() { name = "Goat", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Grass_Flowers = new species() { name = "Grass_Flowers", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Grasshopper = new species() { name = "Grasshopper", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Humans = new species() { name = "Humans", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Lion = new species() { name = "Lion", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Monkey = new species() { name = "Monkey", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Rabbit = new species() { name = "Rabbit", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Shark = new species() { name = "Shark", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Sheep = new species() { name = "Sheep", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Small_Bird = new species() { name = "Small_Bird", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Small_Fish = new species() { name = "Small_Fish", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Stork = new species() { name = "Stork", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Tiger = new species() { name = "Tiger", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Vulture = new species() { name = "Vulture", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };
        species Veggie = new species() { name = "Veggie", wiki = "http://en.wikipedia.org/", sc_name = "Enter Sc Name Here", desc = "Enter Desc Here" };

        Environment_species Land = new Environment_species() { name = "Land" };
        Environment_species Air = new Environment_species() { name = "Air" };
        Environment_species Water = new Environment_species() { name = "Water" };
        Environment_species Green_Cover = new Environment_species() { name = "Green_Cover" };

        Industrial_species City = new Industrial_species() { name = "City" };
        Industrial_species Manufacturing = new Industrial_species() { name = "Manufacturing_Industry" };
        Industrial_species Agriculture = new Industrial_species() { name = "Agriculture" };
        Industrial_species Health = new Industrial_species() { name = "Health" };

        potion Elixir = new potion() { name = "Elixir" , effectiveness = 0.3 };
        potion Vaccine = new potion() { name = "Vaccine" , effectiveness = 0.6 };
        potion Purifier = new potion() { name = "Purifier" , effectiveness = 0.9 };
        potion_infi Boost = new potion_infi() { name = "Boost", effectiveness = 1 };
        
        Coin Coins = new Coin();

        myProgressBar XP = new myProgressBar() {name = "XP"};
        
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


        //------------------------//

        

        public MainPage()
        {
            this.InitializeComponent();

            add_species(all_species);
            link_members(all_species);
            LoadChartContents(all_species);

            add_species(all_env);
            link_members(all_env); 
            LoadChartContents(all_env);

            add_species(all_ind);
            link_members(all_ind);
            LoadChartContents(all_ind);

            add_species(all_pot_animals);
            link_members(all_pot_animals);
            LoadChartContents(all_pot_animals);

            add_species(all_pot_infi);
            link_members(all_pot_infi);
            LoadChartContents(all_pot_infi);

            ////add_species(all_pot_ind);
            //link_members(all_pot_ind);
            //LoadChartContents(all_pot_ind);

            ////add_species(all_pot_env);
            //link_members(all_pot_env);
            //LoadChartContents(all_pot_env);

            add_data_contexts();

            link_members(XP);
        }

        public void add_data_contexts()
        {
            Elixir_flyout_available.DataContext = Elixir;
            Elixir_flyout_timer.DataContext = Elixir;
            Elixir_flyout_g.DataContext = Elixir;

            Vaccine_flyout_available.DataContext = Vaccine;
            Vaccine_flyout_timer.DataContext = Vaccine;
            Vaccine_flyout_g.DataContext = Vaccine;

            Boost_flyout_g.DataContext = Boost;
            Boost_flyout_available.DataContext = Boost;

            Boost_g.DataContext = Boost;
            Boost_available.DataContext = Boost;

            Elixir_flyout1_available.DataContext = Elixir;
            Elixir_flyout1_timer.DataContext = Elixir;
            Elixir_flyout1_g.DataContext = Elixir;

            Purifier_flyout1_available.DataContext = Purifier;
            Purifier_flyout1_timer.DataContext = Purifier;
            Purifier_flyout1_g.DataContext = Purifier;

            ///=============MARKET============////
            Elixir_market_available_button.DataContext = Elixir;
            Elixir_market_available_cost.DataContext = Elixir;
            Elixir_market_maximum_button.DataContext = Elixir;
            Elixir_market_maximum_cost.DataContext = Elixir;
            Elixir_market_timer_button.DataContext = Elixir;
            Elixir_market_timer_cost.DataContext = Elixir;

            Vaccine_market_available_button.DataContext = Vaccine;
            Vaccine_market_available_cost.DataContext = Vaccine;
            Vaccine_market_maximum_button.DataContext = Vaccine;
            Vaccine_market_maximum_cost.DataContext = Vaccine;
            Vaccine_market_timer_button.DataContext = Vaccine;
            Vaccine_market_timer_cost.DataContext = Vaccine;

            Purifier_market_available_button.DataContext = Purifier;
            Purifier_market_available_cost.DataContext = Purifier;
            Purifier_market_maximum_button.DataContext = Purifier;
            Purifier_market_maximum_cost.DataContext = Purifier;
            Purifier_market_timer_button.DataContext = Purifier;
            Purifier_market_timer_cost.DataContext = Purifier;

            Boost_market_available_button.DataContext = Boost;
            Boost_market_available_cost.DataContext = Boost;

            Total_Coins.DataContext = Coins;
        }
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

//=========ON CLICK FUNCTIONS==========//
        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            
            LoadChartContents(all_species);
            LoadChartContents(all_env);
            LoadChartContents(all_ind);

            LoadChartContents(all_pot_animals);
            LoadChartContents(all_pot_infi);
            //LoadChartContents(all_pot_env);
            //LoadChartContents(all_pot_ind);
        }

        //------------------------//

        private void Species_Grid_Clicked(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)//sender =Grid
        {
            // TODO: Add event handler implementation here.

            species sp = grid_obj_to_species(sender);

            sp_Flyout_Title.Text = sp.name;
            sp_Flyout_sc_name.Text = "Sc Name: " + sp.sc_name + " ";
            sp_Flyout_desc.Text = "DESCRIPTION" + '\n' + '\n' + sp.desc;
            sp_Flyout_terrain.Text = "TERRAIN : " + sp.terrain;
            sp_Flyout_status.DataContext = sp;

            sp_Flyout_wiki.NavigateUri = new Uri(sp.wiki);

            sp_Flyout.ShowAt(sp.grid);
            sp.title.Visibility = Visibility.Collapsed;

            //animate_scale(sender, 1.2);
        }
        private void Env_Grid_Clicked(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)//sender =Grid
        {
            // TODO: Add event handler implementation here.

            Environment_species sp = grid_obj_to_env_species(sender);

            env_Flyout_Title.Text = sp.name;
            env_Flyout_desc.Text = "DESCRIPTION" + '\n' + '\n' + sp.desc;
            //myFlyout_wiki.NavigateUri = new Uri(sp.wiki);
            env_Flyout_status.Text = sp.get_status();
            env_Flyout.ShowAt(sp.grid);

            //sp.title.Visibility = Visibility.Collapsed;
            //animate_scale(sender, 1.2);
        }
        private void Ind_Grid_Clicked(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)//sender =Grid
        {
            // TODO: Add event handler implementation here.

            Industrial_species sp = grid_obj_to_ind_species(sender);

            ind_Flyout_Title.Text = sp.name;
            ind_Flyout_desc.Text = "DESCRIPTION" + '\n' + '\n' + sp.desc;
            //myFlyout_wiki.NavigateUri = "http://wiki.com" ;
            ind_Flyout.ShowAt(sp.grid);
            //sp.title.Visibility = Visibility.Collapsed;

            //animate_scale(sender, 1.2);
        }
        private void Potion_Grid_Clicked(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			
			potion sp = grid_obj_to_potion(sender);
            if (sp == null)
            {
                potion_infi sp_infi = grid_obj_to_potion_infi(sender);
                pot_Flyout_Title.Text = sp_infi.name;
                pot_Flyout_refill_time.Text = "Refill Time\nNA";
                pot_Flyout_capacity.Text = "Capacity\nInfinite";
                pot_Flyout_desc.Text = "DESCRIPTION" + '\n' + '\n' + sp_infi.desc;
                pot_Flyout.ShowAt(sp_infi.grid);
            }
            else
            {
                pot_Flyout_Title.Text = sp.name;
                pot_Flyout_refill_time.Text = "Refill Time\n" + sp.max_time.ToString();
                pot_Flyout_capacity.Text = "Capacity\n" + sp.maximum;
                pot_Flyout_desc.Text = "DESCRIPTION" + '\n' + '\n' + sp.desc;
                pot_Flyout.ShowAt(sp.grid);
            }
        }
		
		private void open_market(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			market_Flyout.ShowAt(market_icon);
        }

//===========HOVER START FUNCTIONS==========//
        private void test_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            test.Opacity = 0.5;
            //animate_scale_button(sender, 1.1);
        }
        private void Species_Grid_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)//sender =Grid
        {
            // TODO: Add event handler implementation here.

            species sp = grid_obj_to_species(sender);


            sp.pointer_entered();
            //animate_scale(sender, 1.1);
            
        }


//===========HOVER END FUNCTIONS==========//
        private void Species_Grid_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)//sender = Grid
        {
            // TODO: Add event handler implementation here.

            species sp = grid_obj_to_species(sender);
            
            if(sp_Flyout_Title.Text!=sp.name)
            {
                 sp.pointer_exited();
                 //animate_scale(sender, 1.0);
            }

            
        }

//===============ON CLOSE===============//
        private void sp_flyout_closing(object sender, object e)
        {
            species sp = all_species.Find(x => x.name == sp_Flyout_Title.Text);
            sp.pointer_exited();
            sp_Flyout_Title.Text = "closed";
        }
//===============UTILITY================//
        
        //------------------------//
        
        public species grid_obj_to_species(object obj)
        {
            return all_species.Find(x => (x.name + "_g") == object_to_name(obj));
        }
        public Environment_species grid_obj_to_env_species(object obj)
        {
            return all_env.Find(x => (x.name + "_g") == object_to_name(obj));
        }
        public Industrial_species grid_obj_to_ind_species(object obj)
        {
            return all_ind.Find(x => (x.name + "_g") == object_to_name(obj));
        }
        public potion grid_obj_to_potion(object obj)
        {
            return all_pot_animals.Find(x => (x.name + "_g") == object_to_name(obj));
        }
        public potion_infi grid_obj_to_potion_infi(object obj)
        {
            return all_pot_infi.Find(x => (x.name + "_g") == object_to_name(obj));
        }
        //------------------------//

        public string object_to_name(object sender)
        {
            var spec = sender as Grid;
            var species_name = spec.Name;
            string sp_name = species_name.ToString();
            return sp_name;
        }

        //------------------------//
        
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
        public void link_members(Environment_species sp)
        {
            sp.grid = FindName(sp.name + "_g") as Grid;
            sp.title = FindName(sp.name + "_n") as TextBlock;
            sp.chart = FindName(sp.name + "_Chart") as Chart;
        }
        public void link_members(List<Environment_species> list)
        {
            foreach (Environment_species sp in list)
            {
                link_members(sp);
            }
        }
        public void link_members(Industrial_species sp)
        {
            sp.grid = FindName(sp.name + "_g") as Grid;
            sp.title = FindName(sp.name + "_n") as TextBlock;
            sp.chart = FindName(sp.name + "_Chart") as ProgressBar;
        }
        public void link_members(List<Industrial_species> list)
        {
            foreach (Industrial_species sp in list)
            {
                link_members(sp);
            }
        }

        public void link_members(potion sp)
        {
            sp.grid = FindName(sp.name + "_g") as Grid;
            sp.available_box = FindName(sp.name + "_available") as TextBlock;
            sp.timer_box = FindName(sp.name + "_timer") as TextBlock;
        }
        public void link_members(List<potion> list)
        {
            foreach (potion sp in list)
            {
                link_members(sp);
            }
        }

        public void link_members(potion_infi sp)
        {
            sp.grid = FindName(sp.name + "_g") as Grid;
            sp.available_box = FindName(sp.name + "_available") as TextBlock;
        }
        public void link_members(List<potion_infi> list)
        {
            foreach (potion_infi sp in list)
            {
                link_members(sp);
            }
        }

        public void link_members(myProgressBar sp)
        {
            sp.outer = FindName(sp.name + "_outer") as Border;
            sp.inner = FindName(sp.name + "_inner") as Border;
            sp.Level_box = FindName(sp.name + "_level") as TextBlock;
            sp.value_box = FindName(sp.name + "_value") as TextBlock;
            sp.animate = FindName(sp.name + "_animate") as Storyboard;
            sp.animate_easingkeyframe = FindName(sp.name + "_animate_keyframe") as EasingDoubleKeyFrame;
        }
        //------------------------//
        
        public void add_species(List<species> list)
        {
            list.Add(Aquatic_Plants);
            list.Add(Bee);
            list.Add(Cow);
            list.Add(Deer);
            list.Add(Eagle);
            list.Add(Elephant);
            list.Add(Fruits);
            list.Add(Goat);
            list.Add(Grass_Flowers);
            list.Add(Grasshopper);
            list.Add(Humans);
            list.Add(Lion);
            list.Add(Monkey);
            list.Add(Rabbit);
            list.Add(Shark);
            list.Add(Sheep);  
            list.Add(Small_Bird);
            list.Add(Small_Fish);
            list.Add(Stork);
            list.Add(Tiger);
            list.Add(Vulture);
            list.Add(Veggie);
        }
        public void add_species(List<Environment_species> list)
        {
            list.Add(Land);
            list.Add(Air);
            list.Add(Water);
            list.Add(Green_Cover);
        }
        public void add_species(List<Industrial_species> list)
        {
            list.Add(City);
            list.Add(Manufacturing);
            list.Add(Agriculture);
            list.Add(Health);
        }

        public void add_species(List<potion> list)
        {
            list.Add(Elixir);
            list.Add(Vaccine);
            list.Add(Purifier);
        }
        public void add_species(List<potion_infi> list)
        {
            list.Add(Boost);
        }
        
        //------------------------//
        
        private void LoadChartContents(List<species> list)
        {
            Random rand = new Random();
            foreach (species mySpecies in list)
            {


                ///================Updeate healthy and sick values======================///

                mySpecies.healthy = rand.Next(0, 200);
                mySpecies.sick = rand.Next(0, 200);

                ///=====================================================================///

                //mySpecies.update_population_boxes();
                //mySpecies.update_chart();
            }

        }
        private void LoadChartContents(List<Environment_species> list)
        {
            Random rand = new Random();
            foreach (Environment_species mySpecies in list)
            {


                ///================Updeate healthy and sick values======================///

                mySpecies.healthy = rand.Next(0, 100);

                ///=====================================================================///

                //mySpecies.update_chart();
            }

        }
        private void LoadChartContents(List<Industrial_species> list)
        {
            Random rand = new Random();
            foreach (Industrial_species mySpecies in list)
            {


                ///================Updeate healthy and sick values======================///

                mySpecies.healthy = rand.Next(0, 1000);

                ///=====================================================================///

                //mySpecies.update_chart();
            }

        }

        private void LoadChartContents(List<potion> list)
        {
            foreach (potion mySpecies in list)
            {


                ///================Updeate healthy and sick values======================///

                ///=====================================================================///

                //mySpecies.update_box();
                //mySpecies.update_timer_box();
            }

        }
        private void LoadChartContents(List<potion_infi> list)
        {
            foreach (potion_infi mySpecies in list)
            {


                ///================Updeate healthy and sick values======================///

                ///=====================================================================///

                //mySpecies.update_box();
                //mySpecies.update_timer_box();
            }

        }


        //======================================//
        //==============POTIONS=================//
        //======================================//

        private void animal_potion_pressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            potion pot = all_pot_animals.Find(x => (x.name + "_flyout_g") == object_to_name(sender));
            species sp = all_species.Find(x => x.name == sp_Flyout_Title.Text);

            if (pot == null || sp == null)
            {
                return;
            }

            int xp_change;
            if (pot.name == "Vaccine")
            {
                xp_change = pot.vaccinate(ref sp, new TimeSpan(0,0,10));
                
            }
            else
            {
                xp_change = pot.affect(ref sp);
            }
            XP.Add(xp_change);
            

        }
        private void ind_potion_pressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            potion_infi pot = Boost; ///Unable to copy by reference
            Industrial_species sp = all_ind.Find(x => x.name == ind_Flyout_Title.Text);

            if (pot == null || sp == null)
            {
                return;
            }

            int xp_change = Boost.affect(ref sp); /// Hence, using Boost not pot
            XP.Add(xp_change);
            return;

        }
        private void env_potion_pressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            potion pot = all_pot_animals.Find(x => (x.name + "_flyout1_g") == object_to_name(sender));
            Environment_species sp = all_env.Find(x => x.name == env_Flyout_Title.Text);

            if (pot == null || sp == null)
            {
                return;
            }

            int xp_change = pot.affect(ref sp);
            XP.Add(xp_change);
        }

        private void Market_available_upgrade_click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Name[0])
            {
                case 'E':
                    Elixir.buy_available(ref Coins);
                    break;
                case 'V':
                    Vaccine.buy_available(ref Coins);
                    break;
                case 'P':
                    Purifier.buy_available(ref Coins);
                    break;
                case 'B':
                    Boost.buy_available(ref Coins);
                    break;
                default: 
                    return;
            }
        }
        private void Market_maximum_upgrade_click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Name[0])
            {
                case 'E':
                    Elixir.buy_maximum(ref Coins);
                    break;
                case 'V':
                    Vaccine.buy_maximum(ref Coins);
                    break;
                case 'P':
                    Purifier.buy_maximum(ref Coins);
                    break;
                default:
                    return;
            }
        }
        private void Market_timer_upgrade_click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Name[0])
            {
                case 'E':
                    Elixir.buy_timer(ref Coins);
                    break;
                case 'V':
                    Vaccine.buy_timer(ref Coins);
                    break;
                case 'P':
                    Purifier.buy_timer(ref Coins);
                    break;
                default:
                    return;
            }
        }
        ////=====================DRAG/DROP==================//
        //private void grid_MouseMove(object sender, MouseEventArgs e)
        //{
        //    Ellipse ellipse = sender as Ellipse;
        //    if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        DragDrop.DoDragDrop(ellipse,
        //                             ellipse.Fill.ToString(),
        //                             DragDropEffects.Copy);
        //    }
        //}

        //private void Species_Grid_Dropped(object sender, Windows.UI.Xaml.DragEventArgs e)
        //{
        //    // TODO: Add event handler implementation here.
        //    LoadChartContents(all_species);
			
        //}

        //------------------------//

        //private void Species_Grid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        //{
        //    // TODO: Add event handler implementation here.
        //    species sp = grid_obj_to_species(sender);

        //    myFlyout_Title.Text = sp.name;
        //    myFlyout_sc_name.Text = "Sc Name: " + sp.sc_name + " ";
        //    myFlyout_desc.Text = "DESCRIPTION" + '\n' + '\n' + sp.desc;
        //    //myFlyout_wiki.NavigateUri = "http://wiki.com" ;
        //    myFlyout.ShowAt(sp.grid);
        //    sp.title.Visibility = Visibility.Collapsed;
        //}


        //===========ANIMATIONS===========//
        //public void animate_scale(object sender, double to)
        //{
        //    // TODO: Add event handler implementation here.

            

        //    elastic_scale_1_1.Begin();
        //}
        //public void animate_scale_button(object sender, double to)
        //{
        //    // TODO: Add event handler implementation here.

        //    elastic_scale_1_1_x.To = to;
        //    elastic_scale_1_1_y.To = to;

        //    elastic_scale_1_1.Stop();
        //    Storyboard.SetTargetName(elastic_scale_1_1, (sender as Button).Name);
        //    elastic_scale_1_1.Begin();
        //}

    }

    //===========CLASS DEFINITIONS===========//

    //------------------------//
    
    public class species:INotifyPropertyChanged
    {
        double ext_limit=1;///extinction limit
        public string name { get; set; }
        double _healthy;
        public double healthy
        {
            get
            {
                return _healthy;
            }
            set
            {
                _healthy = value;
                update_chart();
                update_population_boxes();
                update_status();
            }
        }
        double _sick;
        public double sick
        {
            get
            {
                return _sick;
            }
            set
            {
                _sick = value;
                update_chart();
                update_population_boxes();
                update_status();
            }
        }
        public string sc_name { get; set; }
        public string desc { get; set; }
        public string wiki { get; set; }
        public string terrain { get; set; }

        
        /// FOR VACCINATION START///
        public string _status_message;
        public string status_message
        {
            get
            {
                return _status_message;
            }
            set
            {
                _status_message = value;
                OnPropertyChanged("status_message");
            }
        }
        public bool _is_vaccinated;
        public bool is_vaccinated
        {
            get
            {
                return _is_vaccinated;
            }
            set
            {
                _is_vaccinated = value;
                if (grid != null && (healthy+sick > ext_limit ))
                {
                    if (is_vaccinated)
                    {
                        grid.Opacity = 0.8;
                    }
                    else
                    {
                        grid.Opacity = 1;
                    }
                }
                update_status();
            }
        }
        DispatcherTimer vaccine_timer = new DispatcherTimer();
        TimeSpan max_time = new TimeSpan(0, 0, 20);///Setting Max Time
        TimeSpan time_left = new TimeSpan(0,0,0);
        public void vaccinate(TimeSpan input)
        {
            vaccine_timer.Stop();
            max_time = input;
            time_left = max_time;
            is_vaccinated = true;
            vaccine_timer.Start();
        }
        public void setup_timer()
        {
            vaccine_timer.Interval = new TimeSpan(0, 0, 1);
            vaccine_timer.Tick += delegate
            {
                if (time_left.ToString() == "00:00:00")
                {
                    is_vaccinated = false;
                    vaccine_timer.Stop();
                }
                else
                {
                    time_left = time_left.Subtract(new TimeSpan(0, 0, 1));
                    update_status();
                }
            };
        }
        public void update_status()
        {
            if (is_vaccinated)
            {
                status_message = "STATUS\nVaccinated for " + get_vaccine_time() + "\n" + get_status();
            }
            else
            {
                status_message = "STATUS\n" + get_status();
            }
        }
        public string get_vaccine_time()
        {
            return time_left.ToString();
        }
        /// FOR VACCINATION END///
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
            if (chart != null)
            {
                List<Population> data = new List<Population>();
                data.Add(new Population() { Name = "Healthy", Amount = healthy });
                data.Add(new Population() { Name = "Healthy", Amount = sick });
                (chart.Series[0] as PieSeries).ItemsSource = data;
            }
        }
        public void update_population_boxes()
        {
            if (healthy_b != null && sick_b != null)
            {
                healthy_b.Text = healthy.ToString();
                sick_b.Text = sick.ToString();
            }
        }
        public species()
        {
            healthy = 50;
            sick = 50;
            setup_timer();
        }
        public void pointer_entered()
        {
            scale_transform(grid, 1.1, 1.1);


            //SHOW title, population values
            sick_b.Visibility = Visibility.Visible;
            healthy_b.Visibility = Visibility.Visible;
            title.Visibility = Visibility.Visible;

        }
        public void pointer_exited()
        {
            scale_transform(grid, 1, 1);

            //HIDE title, population values
            sick_b.Visibility = Visibility.Collapsed;
            healthy_b.Visibility = Visibility.Collapsed;
            title.Visibility = Visibility.Collapsed;
        }
        public string get_status()
        {
            double total = healthy + sick;

            string dying;
            string iucn;
            if (total == 0)
            {
                iucn = "extinct";
            }
            else if (total < 30)
            {
                iucn = "Critically Endangered";
            }
            else if (total < 100)
            {
                iucn = "Endangered";
            }
            else if (total < 250)
            {
                iucn = "Vulnerable";
            }
            else if (total < 600)
            {
                iucn = "Near Threatened";
            }
            else
            {
                iucn = "Least Concerned";
            }

            double ratio = healthy/sick;

            if (ratio < 0.05)
            {
                dying = "Diminishing Rapidly";
            }
            else if (ratio < 0.2)
            {
                dying = "Dying Quickly";
            }
            else if (ratio < 0.5)
            {
                dying = "Dying";
            }
            else
            {
                return iucn;
            }

            return dying + "\n" + iucn;


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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
    public class Environment_species
    {
        public string name { get; set; }
        double _healthy;
        public double healthy
        {
            get
            {
                return _healthy;
            }
            set
            {
                _healthy = value;
                update_chart();
            }
        }
        public Grid grid { get; set; }
        public string desc { get; set; }
        public Chart chart { get; set; }
        public TextBlock title { get; set; }
        public void update_chart()
        {
            //(chart.Series[0] as PieSeries).ItemsSource = double_list(healthy, sick);
            List<Population> data = new List<Population>();
            data.Add(new Population() { Name = "Healthy", Amount = healthy });
            data.Add(new Population() { Name = "Sick", Amount = 100-healthy });
            (chart.Series[0] as PieSeries).ItemsSource = data;
        }
        public string get_status()
        {
            if (healthy < 10)
            {
                return "STATUS\nPoisoned";
            } else if (healthy < 20)
            {
                return "STATUS\nVery Contaminated";
            } else if (healthy < 40)
            {
                return "STATUS\nPolluted";
            } else if (healthy < 60)
            {
                return "STATUS\nMildly Polluted";
            }
            else if(healthy > 85)
            {
                return "STATUS\nMarvellous";
            }
            else
            {
                return "STATUS\nBearable";
            }
        }

    }
    public class Industrial_species
    {
        public string name { get; set; }
        double _healthy;////0 < healthy <1000
        public double healthy
        {
            get
            {
                return _healthy;
            }
            set
            {
                _healthy = value;
                update_chart();
            }
        } 
        public Grid grid { get; set; }
        public string desc { get; set; }
        public ProgressBar  chart { get; set; }
        public TextBlock title { get; set; }
        public void update_chart()
        {
            chart.Value = healthy / 10;
        }
    }

    //------------------------//

    public class potion : INotifyPropertyChanged
    {
        
        //// affectiveness
        public const double percent_affect = 0.3;

        public string name { get; set; }
        int _available;
        public int available 
        { 
            get{
                return _available;
            }
            set{
                _available= value;
                update_box();
                OnPropertyChanged("available");
                if (grid != null)
                {
                    if (_available == 0)
                    {
                        grid.Opacity = 0.5;
                    }
                    else
                    {
                        grid.Opacity = 1;
                        if (_available == maximum)
                        {
                            timer_box.Visibility = Visibility.Collapsed;
                            reset_timer();
                        }
                        else
                        {
                            timer.Start();
                            timer_box.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }
        int _maximum;
        public int maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                update_box();
                if (!timer.IsEnabled && available < maximum)
                {
                    reset_timer();
                    timer.Start();
                    if(timer_box != null){
                        timer_box.Visibility = Visibility.Visible;
                    }
                }
                OnPropertyChanged("maximum");
            }
        }
        public Grid grid { get; set; }
        TextBlock _available_box;
        public TextBlock available_box 
        {
            get{
                return _available_box;
            }
            set{
                _available_box = value;
                update_box();
                OnPropertyChanged("available_box");
            }
        }
        TextBlock _timer_box;
        public TextBlock timer_box
        {
            get
            {
                return _timer_box;
            }
            set
            {
                _timer_box = value;
                OnPropertyChanged("timer_box");
            }
        }
        public string desc { get; set; }
        public double effectiveness { get; set; }// 0 < effectiveness < 1
        public double min(double a, double b)
        {
            if (a > b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }
        public void update_box()
        {
            if(available_box!=null) available_box.Text = available + "/" + maximum;
        }
        public void update_timer_box()
        {
            if (timer_box != null)
            {
                timer_box.Text = time_left.ToString(@"mm\:ss");
            }
        }
        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan _max_time;
        public TimeSpan max_time
        {
            get
            {
                return _max_time;
            }
            set
            {
                _max_time = value;
                max_time_string = max_time.ToString();
                if (!timer.IsEnabled)
                {
                    reset_timer();
                }
            }
        }
        string _max_time_string;
        public string max_time_string
        {
            get
            {
                return _max_time_string;
            }
            set
            {
                _max_time_string = value;
                OnPropertyChanged("max_time_string");
            }
        }
        TimeSpan time_left = new TimeSpan();
        void reset_timer()
        {
            time_left = max_time;
            update_timer_box();
            timer.Stop();
        }
        public void setup_timer()
        {
            time_left = max_time;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += delegate
            {
                if (time_left.ToString() == "00:00:00")
                {
                    if (available < maximum)
                    {
                        available++;
                        reset_timer();
                        if (available >= maximum)
                        {
                            timer.Stop();
                        }
                        else
                        {
                            timer.Start();
                        }
                    }
                }
                else
                {
                    time_left = time_left.Subtract(new TimeSpan(0, 0, 1));
                    update_timer_box();
                }
            };

            timer.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public potion()
        {
            available = 2;
            maximum = 3;
            max_time = new TimeSpan(0,0,20);///Setting Max Time
            setup_timer();

            Maximum_cost = Available_cost = Timer_cost = 35;
        }
        public int affect(ref Industrial_species sp)
        {
            ////Formula Affecting Change;
            //double change = ((sp.healthy - (percent_affect * effectiveness)) <= 0) ? (sp.healthy * (1 - percent_affect) * effectiveness) : ((sp.healthy - (percent_affect * effectiveness)));
            //sp.healthy = (change > 1000) ? 1000 : change;
            double change = (1000 - sp.healthy) * (percent_affect * effectiveness);
            sp.healthy += change;

            return (int)change;///Formula for Adding XP
        }
        public int affect(ref species sp)
        {
            double change = 0;
            if (available > 0)
            {
                ////Formula Affecting Change;
                change = (sp.sick * (percent_affect) * effectiveness);
                sp.healthy = sp.healthy + change;
                sp.sick = sp.sick - change;
                available--;
            }
            return (int)(change / 2);///Formula adding XP
        }
        public int affect(ref Environment_species sp)
        {
            
            if (available > 0)
            {
                ////Formula Affecting Change;
                //sp.healthy = (((100-sp.healthy) - (percent_affect * effectiveness)) <= 0) ? (sp.healthy * (1 - percent_affect) * effectiveness) : ((sp.healthy - (percent_affect * effectiveness)));
                double change = (100 - sp.healthy) * (percent_affect * effectiveness);
                sp.healthy += change;
                available--;
                return (int)(change * 1.5);//Formula for Adding XP;
            }
            else return 0;
            
        }
        public int vaccinate(ref species sp , TimeSpan time)
        {
            if (available > 0)
            {
                ////Formula Affecting Change;
                sp.vaccinate(time);
                available--;
                return 100; ///formula affecting xp;
            }
            return 0;
        }
        int _available_cost;
        public int Available_cost
        {
            get
            {
                return _available_cost;
            }
            set
            {
                _available_cost = value;
                OnPropertyChanged("Available_cost");
            }
        }
        int _maximum_cost;
        public int Maximum_cost
        {
            get
            {
                return _maximum_cost;
            }
            set
            {
                _maximum_cost = value;
                OnPropertyChanged("Maximum_cost");
            }
        }
        int _timer_cost;
        public int Timer_cost
        {
            get
            {
                return _timer_cost;
            }
            set
            {
                _timer_cost = value;
                OnPropertyChanged("Timer_cost");
            }
        }
        public void buy_available(ref Coin coins)
        {
            if (available < maximum && coins.Coins > Available_cost)
            {
                available++;
                coins.Coins -= Available_cost;
            }
        }
        public void buy_maximum(ref Coin coins)
        {
            if (coins.Coins > Maximum_cost)
            {
                maximum++;
                coins.Coins -= Maximum_cost;
            }
        }
        public void buy_timer(ref Coin coins)
        {
            if (max_time.TotalSeconds >= 15 && coins.Coins > Timer_cost)
            {
                max_time = max_time.Subtract(new TimeSpan(0, 0, 5));
                coins.Coins -= Timer_cost;
            }
        }
    }
    public class potion_infi : INotifyPropertyChanged
    {

        //// affectiveness
        public const double percent_affect = 0.3;

        public string name { get; set; }
        int _available;
        public int available
        {
            get
            {
                return _available;
            }
            set
            {
                _available = value;
                //update_box();
                if (grid != null)
                {
                    if (_available == 0)
                    {
                        grid.Opacity = 0.5;
                    }
                    else
                    {
                        grid.Opacity = 1;
                    }
                }

                OnPropertyChanged("available");
            }
        }
        public Grid grid { get; set; }
        TextBlock _available_box;
        public TextBlock available_box
        {
            get
            {
                return _available_box;
            }
            set
            {
                _available_box = value;
                update_box();
                OnPropertyChanged("available_box");
            }
        }
        public string desc { get; set; }
        public double effectiveness { get; set; }// 0 < effectiveness < 1
        public void update_box()
        {
            if (available_box != null) available_box.Text = available.ToString();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public potion_infi()
        {
            available = 2;
        }
        public int affect(ref Industrial_species sp)
        {
            ////Formula Affecting Change;
            //double change = ((sp.healthy - (percent_affect * effectiveness)) <= 0) ? (sp.healthy * (1 - percent_affect) * effectiveness) : ((sp.healthy - (percent_affect * effectiveness)));
            //sp.healthy = (change > 1000) ? 1000 : change;
            if (available > 0)
            {
                double change = (1000 - sp.healthy) * (percent_affect * effectiveness);
                sp.healthy += change;
                available--;
                return (int)change;///Formula for Adding XP
            }
            else return 0;
        }
        public int affect(ref species sp)
        {
            double change = 0;
            if (available > 0)
            {
                ////Formula Affecting Change;
                change = (sp.sick * (percent_affect) * effectiveness);
                sp.healthy = sp.healthy + change;
                sp.sick = sp.sick - change;
                available--;
            }
            return (int)(change / 2);///Formula adding XP
        }
        public int affect(ref Environment_species sp)
        {
            ////Formula Affecting Change;

            //sp.healthy = (((100-sp.healthy) - (percent_affect * effectiveness)) <= 0) ? (sp.healthy * (1 - percent_affect) * effectiveness) : ((sp.healthy - (percent_affect * effectiveness)));
            double change = (100 - sp.healthy) * (percent_affect * effectiveness);
            sp.healthy += change;
            return (int)(change * 1.5);//Formula for Adding XP;
        }
        int _Available_cost;
        public int Available_cost
        {
            get
            {
                return _Available_cost;
            }
            set
            {
                _Available_cost = value;
                OnPropertyChanged("Available_cost");
            }
        }
        public void buy_available(ref Coin coins)
        {
            if (coins.Coins > Available_cost)
            {
                available++;
                coins.Coins -= Available_cost;
            }
        }

    } 

    public class Population
    {
        public string Name { get; set; }
        public double Amount { get; set; }
    }
    public class myProgressBar
    {
        public string name;
        Border _outer;
        public Border outer
        {
            get
            {
                return _outer;
            }
            set
            {
                _outer = value;
                set_border_dimensions();
            }
        }
        Border _inner;
        public Border inner
        {
            get
            {
                return _inner;
            }
            set
            {
                _inner = value;
                set_border_dimensions();
            }
        }
        TextBlock _level_box;
        public TextBlock Level_box
        {
            get
            {
                return _level_box;
            }
            set
            {
                _level_box = value;
                update_level_box();
            }
        }
        TextBlock _value_box;
        public TextBlock value_box
        {
            get
            {
                return _value_box;
            }
            set
            {
                _value_box = value;
                value_box.Text = Value.ToString() + '/' + max_value.ToString();
            }
        }
        int max_value = 50;///Set initial Max-Value
        int _level;
        int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;

                if (!members_null())
                {
                    update_level_box();///Updating Level_box
                }
            }
        }
        int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (_value >= max_value)
                {



                    while (_value >= max_value)
                    {
                        _value -= max_value;
                        
                        //int add_max = (max_value <= 300) ? max_value : ((int)(((double) max_value) / 3) / 100) * 100;
                        int add_max = Level * 50;                     ///Formula for different levels
                        max_value += add_max;
                        Level++;

                        if (!members_null())
                        {
                            update_value_box();///Updating Value_box
                            update_border_width_animate(max_value); ///Updating Border-Width
                        }
                    }
                }
                else
                {
                    if (!members_null())
                    {
                        update_value_box();///Updating Value_box
                        update_border_width_animate();///Updating Border-Width
                    }
                }
            }
        }
        private bool members_null()
        {
            return (outer == null || inner == null || Level_box == null || value_box == null || animate == null || animate_easingkeyframe == null);
        }
        private void set_border_dimensions()
        {
            if (!members_null())
            {
                inner.Height = outer.ActualHeight;
                inner.HorizontalAlignment = HorizontalAlignment.Left;
            }
        }
        private void update_level_box()
        {
            if (!members_null())
            {
                Level_box.Text = "Level: " + Level.ToString();
            }
        }
        private void update_value_box()
        {
            if (!members_null())
            {
                value_box.Text = Value.ToString() + '/' + max_value.ToString();
            }
        }
        private void update_border_width_animate(int Input = 0)
        {
            if (!members_null())
            {
                //animate.Stop();
                //inner.Width = outer.ActualWidth * _value / max_value;
                animate_easingkeyframe.Value = outer.ActualWidth * Input / max_value;
                animate.Begin();
            }
        }
        private void update_border_width_animate()
        {
            if (!members_null())
            {
                //animate.Stop();
                //inner.Width = outer.ActualWidth * _value / max_value;
                animate_easingkeyframe.Value = outer.ActualWidth * Value / max_value;
                animate.Begin();
            }
        }
        private void update_border_width(int Input)
        {
            if (!members_null())
            {
                //inner.Width = outer.ActualWidth * _value / max_value;
                inner.Width = outer.ActualWidth * Input / max_value;
            }
        }
        private void update_border_width()
        {
            if (!members_null())
            {
                //inner.Width = outer.ActualWidth * _value / max_value;
                inner.Width = outer.ActualWidth * Value / max_value;
            }
        }
        public void Add(int change)
        {
            Value += change;
        }
        public myProgressBar()
        {
            Value = 10;//test
            Level = 1;
        }
        public Storyboard _animate;
        public Storyboard animate
        {
            get
            {
                return _animate;
            }
            set
            {
                _animate = value;
                animate.Completed += animate_Completed;
            }
        }

        void animate_Completed(object sender, object e)
        {
            if (inner.ActualWidth == outer.ActualWidth)
            {
                update_border_width(0);
                update_border_width_animate(0);
                update_border_width_animate();
            }
        }
        public EasingDoubleKeyFrame animate_easingkeyframe;
    }
    public class Coin : INotifyPropertyChanged
    {
        int _coins;
        public int Coins
        {
            get
            {
                return _coins;
            }
            set
            {
                _coins = value;
                OnPropertyChanged("Coins");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public Coin()
        {
            Coins = 200;
        }
    }

    ////===============CONVERTERS===================////

    //public class species_to_chart_itemsource_converter : IValueConverter
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

}