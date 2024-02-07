using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_лифт_
{
    class Lift
    {
        private Doors doors;
        private int currentFloor;
        private int buildingFloors;

        public Lift(int buildingFloors)
        {
            this.buildingFloors = buildingFloors;
            doors = Doors.Closed;
            currentFloor = 1;
        }

        enum Doors
        {
            Open,
            Closed
        }

        public void OpenDoors()
        {
            doors = Doors.Open;
        }

        public void CloseDoors()
        {
            doors = Doors.Closed;
        }

        /// <summary>
        /// Переместиться на другой этаж
        /// </summary>
        /// <param name="i">Этаж</param>
        /// <returns>Успех</returns>
        public bool ChangeFloor(int i)
        {
            if (i <= buildingFloors && doors == Doors.Closed)
            {
                currentFloor = i;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Вернуть строку состояния лифта
        /// </summary>
        /// <returns>Состояние лифта</returns>
        public string Status()
        {
            string status = "Floor: " + currentFloor.ToString() + ", ";
            if (doors == Doors.Closed) status += "doors closed.";
            else status += "doors opened.";
            return status;
        }
    }
}
