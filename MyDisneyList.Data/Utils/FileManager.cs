﻿using MyDisneyList.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MyDisneyList.Data.Utils
{
    public static class FileManager
    {
        public static string FilePath = Assembly.GetExecutingAssembly().Location;
        public static string FileName = @"movies.json";

        public static void WriteMoviesToJson(List<Movie> movies, string path = null, string filename = null)
        {
            string fullPath = $@"{(string.IsNullOrWhiteSpace(path) ? FilePath : path)}\\{(string.IsNullOrWhiteSpace(filename) ? FileName : filename)}";

            try
            {
                using (StreamWriter file = File.CreateText(fullPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, movies);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static List<Movie> ReadMoviesFromJson(string path = null, string filename = null)
        {
            string fullPath = $@"{(string.IsNullOrWhiteSpace(path) ? FilePath : path)}\\{(string.IsNullOrWhiteSpace(filename) ? FileName : filename)}";

            try
            {
                using (StreamReader file = File.OpenText(fullPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (List<Movie>)serializer.Deserialize(file, typeof(List<Movie>));
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static bool MovieFileExists(string path = null, string filename = null)
        {
            string fullPath = $@"{(string.IsNullOrWhiteSpace(path) ? FilePath : path)}\\{(string.IsNullOrWhiteSpace(filename) ? FileName : filename)}";

            return File.Exists(fullPath);
        }

        public static void DeleteFile(string path = null, string filename = null)
        {
            string fullPath = $@"{(string.IsNullOrWhiteSpace(path) ? FilePath : path)}\\{(string.IsNullOrWhiteSpace(filename) ? FileName : filename)}";

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
