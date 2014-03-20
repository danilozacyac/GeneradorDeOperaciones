using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GeneradorDeOperaciones.Printable;
using GeneradorDeOperaciones.Utilities;
using Telerik.Windows.Controls;

namespace GeneradorDeOperaciones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Operaciones> sumas = new List<Operaciones>(), restas = new List<Operaciones>(),
            multi = new List<Operaciones>(), divi = new List<Operaciones>();
        double counter = 0;
        private int grade = 0;

        String startUpPath = "";//System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly(‌​).CodeBase);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            startUpPath =  AppDomain.CurrentDomain.BaseDirectory;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (grade == 0)
            {
                MessageBox.Show("Seleccione el nivel de dificultad de las operaciones");
                return;
            }


            counter = 0;
            AppUtilities.random = new Random(DateTime.Now.Millisecond);
            if (RtbSumas.IsChecked == true)
            {
                
                while (counter < RnudSumas.Value)
                {
                    sumas.Add(GeneraOperaciones.GetSuma(grade));
                    counter++;
                }
            }

            counter = 0;
            if (RtgRestas.IsChecked == true)
            {
                while (counter < RnudRestas.Value)
                {
                    restas.Add(GeneraOperaciones.GetResta(grade));
                    counter++;
                }
            }

            counter = 0;
            if (RtgMulti.IsChecked == true)
            {
                while (counter < RnudMulti.Value)
                {
                    multi.Add(GeneraOperaciones.GetMultiplicacion(grade));
                    counter++;
                }
            }

            counter = 0;
            if (RtgDivision.IsChecked == true)
            {
                while (counter < RnudDivisiones.Value)
                {
                    divi.Add(GeneraOperaciones.GetDivision(grade));
                    counter++;
                }
            }


            ImprimeOperaciones imprime = new ImprimeOperaciones(sumas, restas, multi, divi);
            imprime.Operaciones();

            AppUtilities.random = null;
            sumas = new List<Operaciones>();
            restas = new List<Operaciones>();
            multi = new List<Operaciones>();
            divi = new List<Operaciones>();
        }

        private void GradeChecked(object sender, RoutedEventArgs e)
        {
            grade = Convert.ToInt32(((RadRadioButton)sender).Tag);
        }

        
    }
}
