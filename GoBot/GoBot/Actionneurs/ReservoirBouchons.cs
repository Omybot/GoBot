﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    public static class ReservoirBouchons
    {
        public static void Ouvrir()
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBacBouchons, 0);
        }

        public static void Fermer()
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBacBouchons, 1000);
        }		
    }
}
