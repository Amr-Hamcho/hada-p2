//Author: Amr Hamcho
using System;
using System.Collections.Generic;
namespace Hada
{
    public class Autovia : EventArgs
    {
        public Vehiculo[] highway;
        private List<Vehiculo> sList;
        private List<Vehiculo> tList;
        private List<Vehiculo> cList;

        List<Vehiculo> mlist { get; set; }

        public Autovia(int nc)
        {
            Vehiculo[] highway = new Vehiculo[nc];


            for (int i = 0; i < nc; i++)
            {
                highway[i] = new Vehiculo("coche_" + i, 50, 50, 50);
            }

            // connect the drivers

        }

        public bool moverCoches()
        {

            for (int x = 0; x < highway.Length; x++)

            {
                if (highway[x].todoOk())
                {
                    highway[x].mover();

                    return true;
                }

            }

            return false;    //double check

        }


        void moverCochesEnBucle()
        {

            for (int x = 0; x < highway.Length; x++)

            {
                while (highway[x].todoOk())
                {
                    highway[x].mover();

                }

            }

        }



        public List<Vehiculo> getCochesExcedenLimiteVelocidad()
        {

            sList = new List<Vehiculo>();
            for (int i = 0; i < highway.Length; i++)
            {

                highway[i].velocidadMaximaExcedida += cuandoVelocidadMaximaExcedida;

                sList.Add(highway[i]);

            }




            return sList;
        }

        public List<Vehiculo> getCochesExcedenLimiteTemperatura()
        {
            tList = new List<Vehiculo>();

            for (int i = 0; i < highway.Length; i++)
            {

                highway[i].temperaturaMaximaExcedida += cuandoTemperaturaMaximaExcedida;

                tList.Add(highway[i]);

            }

            return tList;

        }


        public List<Vehiculo> getCochesExcedenMinimoCombustible()
        {
            cList = new List<Vehiculo>();

            for (int i = 0; i < highway.Length; i++)
            {

                highway[i].combustibleMinimoExcedido += cuandoCombustibleMinimoExcedido;

                cList.Add(highway[i]);

            }

            return cList;
        }

        //private void e_handler(object sender,EventArgs args)
        //{
        //    Console.Write("The handler was reached");
        //}


        public override string ToString()
        {
         
            for (int i = 0; i < highway.Length; i++)
            {
                return "[AUTOVÍA] Exceso velocida:" + getCochesExcedenLimiteVelocidad() + "; Exceso temperatura:"
                    + getCochesExcedenLimiteTemperatura() + "; Déficit combustible:  "+ getCochesExcedenMinimoCombustible() + "\n"+
                    "[coche_" + i + "]Velocidad:" + highway[i].velocidad + "km/h;Temperatura:"
                    + highway[i].temperatura
                    + "oC; Combustible:" + highway[i].combustible + "%; Ok: " + highway[i].todoOk() + "\n";
            }

            return "";
            

        }

        void cuandoVelocidadMaximaExcedida(object sender, EventArgs args)
        {
            Vehiculo v = (Hada.Vehiculo)sender;
            Console.Write("¡¡Velocidad máxima excedida!!");
            Console.WriteLine(" Vehículo: " + v.nombre);
            Console.WriteLine("Velocidad: " + v.velocidad + "km/h");


        }

        void cuandoTemperaturaMaximaExcedida(object sender, EventArgs args)
        {
            Vehiculo v = (Hada.Vehiculo)sender;
            Console.Write("¡¡Temperatura máxima excedida!!!");
            Console.WriteLine(" Vehículo: " + v.nombre);
            Console.WriteLine(" Temperatura: " + v.temperatura + "oC");
        }

        void cuandoCombustibleMinimoExcedido(object sender, EventArgs args)
        {
            Vehiculo v = (Hada.Vehiculo)sender;
            Console.Write("¡¡Combustible mínimo excedido!!");
            Console.WriteLine(" Vehículo: " + v.nombre);
            Console.WriteLine(" Combustible: " + v.combustible + "%");
        }









    }
}

        
    
