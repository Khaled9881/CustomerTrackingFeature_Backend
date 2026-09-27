using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CustomerTracking.Domain.Models;

namespace CustomerTracking.Infrastructure.DataSeeding
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Governorate>().HasData(
                new Governorate { Id = 1, Name = "Cairo" },
                new Governorate { Id = 2, Name = "Alexandria" },
                new Governorate { Id = 3, Name = "Giza" },
                new Governorate { Id = 4, Name = "Qalyubia" },
                new Governorate { Id = 5, Name = "Dakahlia" },
                new Governorate { Id = 6, Name = "Sharqia" },
                new Governorate { Id = 7, Name = "Gharbia" },
                new Governorate { Id = 8, Name = "Monufia" },
                new Governorate { Id = 9, Name = "Beheira" },
                new Governorate { Id = 10, Name = "Kafr El Sheikh" },
                new Governorate { Id = 11, Name = "Damietta" },
                new Governorate { Id = 12, Name = "Port Said" },
                new Governorate { Id = 13, Name = "Ismailia" },
                new Governorate { Id = 14, Name = "Suez" },
                new Governorate { Id = 15, Name = "North Sinai" },
                new Governorate { Id = 16, Name = "South Sinai" },
                new Governorate { Id = 17, Name = "Beni Suef" },
                new Governorate { Id = 18, Name = "Faiyum" },
                new Governorate { Id = 19, Name = "Minya" },
                new Governorate { Id = 20, Name = "Assiut" },
                new Governorate { Id = 21, Name = "Sohag" },
                new Governorate { Id = 22, Name = "Qena" },
                new Governorate { Id = 23, Name = "Luxor" },
                new Governorate { Id = 24, Name = "Aswan" },
                new Governorate { Id = 25, Name = "Red Sea" },
                new Governorate { Id = 26, Name = "New Valley" },
                new Governorate { Id = 27, Name = "Matrouh" }
            );

            modelBuilder.Entity<City>().HasData(
                // Cairo (1)
                new City { Id = 1, Name = "Nasr City", GovernorateId = 1 },
                new City { Id = 2, Name = "Maadi", GovernorateId = 1 },
                new City { Id = 3, Name = "Heliopolis", GovernorateId = 1 },
                new City { Id = 4, Name = "Downtown Cairo", GovernorateId = 1 },
                new City { Id = 5, Name = "New Cairo", GovernorateId = 1 },

                // Alexandria (2)
                new City { Id = 6, Name = "Sidi Gaber", GovernorateId = 2 },
                new City { Id = 7, Name = "Miami", GovernorateId = 2 },
                new City { Id = 8, Name = "Smouha", GovernorateId = 2 },
                new City { Id = 9, Name = "Montaza", GovernorateId = 2 },
                new City { Id = 10, Name = "Al Agamy", GovernorateId = 2 },

                // Giza (3)
                new City { Id = 11, Name = "Dokki", GovernorateId = 3 },
                new City { Id = 12, Name = "Mohandessin", GovernorateId = 3 },
                new City { Id = 13, Name = "6th of October", GovernorateId = 3 },
                new City { Id = 14, Name = "Haram", GovernorateId = 3 },
                new City { Id = 15, Name = "Sheikh Zayed", GovernorateId = 3 },

                // Qalyubia (4)
                new City { Id = 16, Name = "Banha", GovernorateId = 4 },
                new City { Id = 17, Name = "Shubra El Kheima", GovernorateId = 4 },
                new City { Id = 18, Name = "Qalyub", GovernorateId = 4 },

                // Dakahlia (5)
                new City { Id = 19, Name = "Mansoura", GovernorateId = 5 },
                new City { Id = 20, Name = "Talkha", GovernorateId = 5 },
                new City { Id = 21, Name = "Mit Ghamr", GovernorateId = 5 },

                // Sharqia (6)
                new City { Id = 22, Name = "Zagazig", GovernorateId = 6 },
                new City { Id = 23, Name = "10th of Ramadan", GovernorateId = 6 },
                new City { Id = 24, Name = "Belbeis", GovernorateId = 6 },

                // Gharbia (7)
                new City { Id = 25, Name = "Tanta", GovernorateId = 7 },
                new City { Id = 26, Name = "Al Mahalla Al Kubra", GovernorateId = 7 },
                new City { Id = 27, Name = "Kafr El Zayat", GovernorateId = 7 },

                // Monufia (8)
                new City { Id = 28, Name = "Shibin El Kom", GovernorateId = 8 },
                new City { Id = 29, Name = "Menouf", GovernorateId = 8 },
                new City { Id = 30, Name = "Sadat City", GovernorateId = 8 },

                // Beheira (9)
                new City { Id = 31, Name = "Damanhur", GovernorateId = 9 },
                new City { Id = 32, Name = "Kafr El Dawwar", GovernorateId = 9 },
                new City { Id = 33, Name = "Rashid", GovernorateId = 9 },

                // Kafr El Sheikh (10)
                new City { Id = 34, Name = "Kafr El Sheikh City", GovernorateId = 10 },
                new City { Id = 35, Name = "Desouk", GovernorateId = 10 },
                new City { Id = 36, Name = "Baltim", GovernorateId = 10 },

                // Damietta (11)
                new City { Id = 37, Name = "Damietta City", GovernorateId = 11 },
                new City { Id = 38, Name = "Ras El Bar", GovernorateId = 11 },
                new City { Id = 39, Name = "Faraskur", GovernorateId = 11 },

                // Port Said (12)
                new City { Id = 40, Name = "Port Fouad", GovernorateId = 12 },
                new City { Id = 41, Name = "Al Manakh", GovernorateId = 12 },
                new City { Id = 42, Name = "Al Zohour", GovernorateId = 12 },

                // Ismailia (13)
                new City { Id = 43, Name = "Ismailia City", GovernorateId = 13 },
                new City { Id = 44, Name = "Fayed", GovernorateId = 13 },
                new City { Id = 45, Name = "Qantara", GovernorateId = 13 },

                // Suez (14)
                new City { Id = 46, Name = "Suez City", GovernorateId = 14 },
                new City { Id = 47, Name = "Ain Sokhna", GovernorateId = 14 },
                new City { Id = 48, Name = "Arbaeen", GovernorateId = 14 },

                // North Sinai (15)
                new City { Id = 49, Name = "Arish", GovernorateId = 15 },
                new City { Id = 50, Name = "Sheikh Zuweid", GovernorateId = 15 },
                new City { Id = 51, Name = "Rafah", GovernorateId = 15 },

                // South Sinai (16)
                new City { Id = 52, Name = "Sharm El Sheikh", GovernorateId = 16 },
                new City { Id = 53, Name = "Dahab", GovernorateId = 16 },
                new City { Id = 54, Name = "Saint Catherine", GovernorateId = 16 },

                // Beni Suef (17)
                new City { Id = 55, Name = "Beni Suef City", GovernorateId = 17 },
                new City { Id = 56, Name = "Nasser", GovernorateId = 17 },
                new City { Id = 57, Name = "Al Fashn", GovernorateId = 17 },

                // Faiyum (18)
                new City { Id = 58, Name = "Faiyum City", GovernorateId = 18 },
                new City { Id = 59, Name = "Sinnuris", GovernorateId = 18 },
                new City { Id = 60, Name = "Tamiya", GovernorateId = 18 },

                // Minya (19)
                new City { Id = 61, Name = "Minya City", GovernorateId = 19 },
                new City { Id = 62, Name = "Mallawi", GovernorateId = 19 },
                new City { Id = 63, Name = "Beni Mazar", GovernorateId = 19 },

                // Assiut (20)
                new City { Id = 64, Name = "Assiut City", GovernorateId = 20 },
                new City { Id = 65, Name = "Dairut", GovernorateId = 20 },
                new City { Id = 66, Name = "Abnub", GovernorateId = 20 },

                // Sohag (21)
                new City { Id = 67, Name = "Sohag City", GovernorateId = 21 },
                new City { Id = 68, Name = "Akhmim", GovernorateId = 21 },
                new City { Id = 69, Name = "Girga", GovernorateId = 21 },

                // Qena (22)
                new City { Id = 70, Name = "Qena City", GovernorateId = 22 },
                new City { Id = 71, Name = "Nag Hammadi", GovernorateId = 22 },
                new City { Id = 72, Name = "Qus", GovernorateId = 22 },

                // Luxor (23)
                new City { Id = 73, Name = "Luxor City", GovernorateId = 23 },
                new City { Id = 74, Name = "Esna", GovernorateId = 23 },
                new City { Id = 75, Name = "Armant", GovernorateId = 23 },

                // Aswan (24)
                new City { Id = 76, Name = "Aswan City", GovernorateId = 24 },
                new City { Id = 77, Name = "Kom Ombo", GovernorateId = 24 },
                new City { Id = 78, Name = "Edfu", GovernorateId = 24 },

                // Red Sea (25)
                new City { Id = 79, Name = "Hurghada", GovernorateId = 25 },
                new City { Id = 80, Name = "Marsa Alam", GovernorateId = 25 },
                new City { Id = 81, Name = "Safaga", GovernorateId = 25 },

                // New Valley (26)
                new City { Id = 82, Name = "Kharga", GovernorateId = 26 },
                new City { Id = 83, Name = "Dakhla", GovernorateId = 26 },
                new City { Id = 84, Name = "Farafra", GovernorateId = 26 },

                // Matrouh (27)
                new City { Id = 85, Name = "Marsa Matrouh", GovernorateId = 27 },
                new City { Id = 86, Name = "Sallum", GovernorateId = 27 },
                new City { Id = 87, Name = "Sidi Barrani", GovernorateId = 27 }
            );
        }
    }

}
