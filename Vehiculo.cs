//Author: Amr Hamcho
using System;
namespace Hada
{
    public class Vehiculo
    {
        /*
         * Public Auto-implemented properties
        */ 
        public static int maxVelocidad // maximum speed allowed,
        {
            get;set;
        }
        public static int maxTemperatura // maximum temperature allowed,
        {
            get; set;
        }
        public static int minCombustible // minimum fuel threshold
        {
            get; set;
        }

        public static Random rand // random number generator
        {
            private get; set;
        }

        public string nombre  // save the name of the vehicle
        {
            get; private set;
        }

        /*****************************************************/

        /*
         * private properties
        */

        private int _velocidad, _temperatura​, _combustible​;

        public int velocidad
        {
            get
            {
                return _velocidad;
            }

            set
            {
                _velocidad = value;
                if(_velocidad > maxVelocidad)
                {
                    // here an event "velocidadMaximaExcedida" will be triggered

                    velocidadMaximaExcedida(this, new VelocidadMaximaExcedidaArgs(value));
                }

                else if(_velocidad < 0)
                {
                    _velocidad = 0;
                }

       
            }
            
        }



        public int temperatura
        {
            get
            {
                return _temperatura;
            }

            set
            {
                _temperatura = value;
                if (_temperatura > maxTemperatura)
                {
                    // here an event "temperaturaMaximaExcedida" will be triggered
                    temperaturaMaximaExcedida(this, new TemperaturaMaximaExcedidaArgs(value));
                    
                }


            }

        }


        public int combustible
        {
            get
            {
                return _combustible;
            }

            set
            {
                _combustible = value;
                if (_temperatura < minCombustible)
                {
                    // here an event "combustibleMinimoExcedido" will be triggered
                    combustibleMinimoExcedido(this, new CombustibleMinimoExcedidoArgs(value));
                }

                else if (_combustible < 0)       //if the value is less than 0
                {
                    _combustible = 0;            //we assign 0
                }

                else if (_combustible > 100) //if the value is bigger than 100 
                {
                    _combustible = 100;     //we assign 100
                }

            }

        }

        /*****************************************************/

        /*
         * Methods implemented for this class
         */

        public Vehiculo(string nombre, int velocidad, int temperatura, int combustible)
        {
            this.nombre = nombre;
            this.velocidad = velocidad;
            this.temperatura = temperatura;
            this.combustible = combustible;
        }

        public void incVelocidad()
        {
            velocidad = velocidad + rand.Next(1 , 7); // increaase the speed with a random number between 1 and 7
        }


        public void incTemperatura()
        {
            temperatura = temperatura + rand.Next(1, 5);// increaase the temp with a random number between 1 and 5
        }

        public void decCombustible()
        {
            combustible = combustible - rand.Next(1, 5);
        }


        public bool todoOk()
        {
            if (temperatura <= maxTemperatura && combustible >= minCombustible)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public void mover()
        {
            if (todoOk())
            {
                incVelocidad(); incTemperatura(); decCombustible();
            }
        }


        public override string ToString()
        {
            return "[" + nombre + "] Velocidad:" + velocidad + "km/h; Temperatura:" + temperatura +
                "oC; Combustible:" + combustible + "%; Ok:" + todoOk();



        }


        /*****************************************************/

        /*
         * Events
         */

        public event EventHandler<VelocidadMaximaExcedidaArgs> velocidadMaximaExcedida;

        public event EventHandler<TemperaturaMaximaExcedidaArgs> temperaturaMaximaExcedida;
    
        public event EventHandler<CombustibleMinimoExcedidoArgs> combustibleMinimoExcedido;

    

     public class CombustibleMinimoExcedidoArgs : EventArgs
        {
            public int combustible​
            {

                 get; set;
             }

            public CombustibleMinimoExcedidoArgs( int combu )
                {
                combustible​ = combu;
                }

        }

        /*****************************************************/

        public class TemperaturaMaximaExcedidaArgs : EventArgs
        {
            public int temperatura
            {
                get; set;
            }

            public TemperaturaMaximaExcedidaArgs(int temp)
            {
                temperatura = temp;
            }
        }

        /*****************************************************/

        public class VelocidadMaximaExcedidaArgs : EventArgs
        {
            public int velocidad
            {
                get;set;
            }

            public VelocidadMaximaExcedidaArgs(int velo)
            {
                velocidad = velo;
            }

        }

        /*****************************************************/



    }
}
