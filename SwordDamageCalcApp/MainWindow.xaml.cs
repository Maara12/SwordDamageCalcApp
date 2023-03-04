using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwordDamageCalcApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static Random random = new Random();
        SwordDamage swordDamage;
        int initialroll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        

        public MainWindow()
        {
            InitializeComponent();
            swordDamage = new SwordDamage(initialroll);
            DisplayDamage();
        }

        private void RollDice()
        {
            swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            DisplayDamage();
        }

        private void DisplayDamage()
        {
            
            damage.Text = $"Rolled {swordDamage.Roll} for { swordDamage.Damage} HP";

        }

        private void Flaming_Checked(object sender, RoutedEventArgs e)
        {
            
            swordDamage.Flaming = 2;
            DisplayDamage();
        }

        private void FLaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = 0;
            DisplayDamage();
        }

        private void Magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = 1f;
            DisplayDamage();
            
        }

        private void Magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = 1.75f;
            DisplayDamage();
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            RollDice();
        }
    }

    class SwordDamage
    {
        private const int BASE_DAMAGE = 3;
        private int roll;

        private int flaming;
        private float magic = 1f;

        /// <summary>
        /// Constructs an SwordDamage Object
        /// </summary>
        /// <param name="roll"> takes random integer dice roll as parameter </param>
        public SwordDamage(int roll)
        {
            Roll = roll;
            CalculateDamage();
        }

        /// <summary>
        /// Final Damage inflicted by sword
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// random integer from a dice roll
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// flaming damage value
        /// </summary>
        public int Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Magic damage value
        /// </summary>
        public float Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        private void CalculateDamage()
        {
            Damage = (int)(Roll * Magic) + BASE_DAMAGE + Flaming;

        }


    }
}
