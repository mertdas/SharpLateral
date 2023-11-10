using System;

namespace RedPersist
{
    internal class Information
    {
        public static void Banner()
        {
            var bannerText = @"                    
           _____ _                      _           _                 _ 
          / ____| |                    | |         | |               | |
         | (___ | |__   __ _ _ __ _ __ | |     __ _| |_ ___ _ __ __ _| |
          \___ \| '_ \ / _` | '__| '_ \| |    / _` | __/ _ \ '__/ _` | |
          ____) | | | | (_| | |  | |_) | |___| (_| | ||  __/ | | (_| | |
         |_____/|_| |_|\__,_|_|  | .__/|______\__,_|\__\___|_|  \__,_|_|
                                 | |                                    
                                 |_|                                    

                                             

                                Mert Das @merterpreter
                                   version: v1.0
           

        ";
            Console.WriteLine(bannerText);
        }
    }
}