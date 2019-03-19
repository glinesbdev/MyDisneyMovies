using System;
using System.Collections.Generic;
using System.Text;

namespace MyDisneyMovies.Core.Tests.Helpers
{
    public static class JsonManagerTestHelper
    {
        public static string ValidJsonBlob = @"{
            ""page"": 2,
            ""total_results"": 531,
            ""total_pages"": 27,
            ""results"": [{
              ""popularity"": 6.846,
              ""media_type"": ""person"",
              ""id"": 2106,
              ""profile_path"": ""/mrcVG49U2PVm1LpPMmwBtn5ZzOh.jpg"",
              ""name"": ""Walt Disney"",
              ""known_for"": [
                {
                  ""vote_average"": 7,
                  ""vote_count"": 3844,
                  ""id"": 408,
                  ""video"": false,
                  ""media_type"": ""movie"",
                  ""title"": ""Snow White and the Seven Dwarfs"",
                  ""popularity"": 17.938,
                  ""poster_path"": ""/wbVGRBYPRRahIZNGXY9TfHDUSc2.jpg"",
                  ""original_language"": ""en"",
                  ""original_title"": ""Snow White and the Seven Dwarfs"",
                  ""genre_ids"": [
                    14,
                    16,
                    10751
                  ],
                  ""backdrop_path"": ""/c66otZnSdri67kR7ps92kRX849o.jpg"",
                  ""adult"": false,
                  ""overview"": ""A beautiful girl, Snow White, takes refuge in the forest in the house of seven dwarfs to hide from her stepmother, the wicked Queen. The Queen is jealous because she wants to be known as 'the fairest in the land', and Snow White's beauty surpasses her own."",
                  ""release_date"": ""1937-12-20""
                },
                {
                  ""vote_average"": 6.9,
                  ""vote_count"": 3389,
                  ""id"": 11224,
                  ""video"": false,
                  ""media_type"": ""movie"",
                  ""title"": ""Cinderella"",
                  ""popularity"": 15.348,
                  ""poster_path"": ""/cdf4J7tDhSPAghWWgx9EnwQWBfF.jpg"",
                  ""original_language"": ""en"",
                  ""original_title"": ""Cinderella"",
                  ""genre_ids"": [
                    10751,
                    14,
                    16,
                    10749
                  ],
                  ""backdrop_path"": ""/xSN1cpugrzi8DjpVxtHeRRlbB6Q.jpg"",
                  ""adult"": false,
                  ""overview"": ""Cinderella has faith her dreams of a better life will come true. With help from her loyal mice friends and a wave of her Fairy Godmother's wand, Cinderella's rags are magically turned into a glorious gown and off she goes to the Royal Ball. But when the clock strikes midnight, the spell is broken, leaving a single glass slipper... the only key to the ultimate fairy-tale ending!"",
                  ""release_date"": ""1950-03-04""
                },
                {
                  ""vote_average"": 7.2,
                  ""vote_count"": 3281,
                  ""id"": 9325,
                  ""video"": false,
                  ""media_type"": ""movie"",
                  ""title"": ""The Jungle Book"",
                  ""popularity"": 13.271,
                  ""poster_path"": ""/1AreNcL9s24Qfghbzomy0IlzCFk.jpg"",
                  ""original_language"": ""en"",
                  ""original_title"": ""The Jungle Book"",
                  ""genre_ids"": [
                    10751,
                    16,
                    12
                  ],
                  ""backdrop_path"": ""/pfSLaXhojt0cNU6lWRGxvbQ2HWi.jpg"",
                  ""adult"": false,
                  ""overview"": ""The boy Mowgli makes his way to the man-village with Bagheera, the wise panther. Along the way he meets jazzy King Louie, the hypnotic snake Kaa and the lovable, happy-go-lucky bear Baloo, who teaches Mowgli 'The Bare Necessities' of life and the true meaning of friendship."",
                  ""release_date"": ""1967-10-17""
                }
              ],
              ""adult"": false
            },
            {
              ""vote_average"": 0,
              ""vote_count"": 0,
              ""id"": 468228,
              ""video"": false,
              ""media_type"": ""movie"",
              ""title"": ""The Disney of Duivendrecht"",
              ""popularity"": 0.6,
              ""poster_path"": ""/kJRZ38zJTLXrHd39VivTKY9Ywcp.jpg"",
              ""original_language"": ""en"",
              ""original_title"": ""De Duivendrechtse Disney"",
              ""genre_ids"": [
                99
              ],
              ""backdrop_path"": null,
              ""adult"": false,
              ""overview"": ""Documentary on the groundbreaking animation films with which the Dutch animation pioneer Joop Geesink conquered the world."",
              ""release_date"": ""2012-09-01""
            },
            {
              ""vote_average"": 5.5,
              ""vote_count"": 2,
              ""id"": 479098,
              ""video"": false,
              ""media_type"": ""movie"",
              ""title"": ""Disney Animation Classic: Volume 6"",
              ""popularity"": 0.6,
              ""poster_path"": ""/7h1qirQP0XNdBWSifZCSV2c3rV5.jpg"",
              ""original_language"": ""hu"",
              ""original_title"": ""Disney Animation Classic: Volume 6"",
              ""genre_ids"": [],
              ""backdrop_path"": ""/ydaYd3gL6Oylo9sxVYkDBBReUqO.jpg"",
              ""adult"": false,
              ""overview"": """",
              ""release_date"": """"
            },
            {
              ""vote_average"": 10,
              ""vote_count"": 1,
              ""id"": 479099,
              ""video"": false,
              ""media_type"": ""movie"",
              ""title"": ""Disney Animation Classic: Volume 3"",
              ""popularity"": 0.6,
              ""poster_path"": ""/qVwSrdntGhG5CxsTby8fddSwjUf.jpg"",
              ""original_language"": ""hu"",
              ""original_title"": ""Disney Animation Classic: Volume 3"",
              ""genre_ids"": [],
              ""backdrop_path"": ""/rrzYa3ocbY6Q1hjfupMOwyMMTDt.jpg"",
              ""adult"": false,
              ""overview"": """",
              ""release_date"": """"
            },
            {
                ""original_name"": ""Disney Time"",
                ""id"": 15688,
                ""media_type"": ""tv"",
                ""name"": ""Disney Time"",
                ""vote_count"": 0,
                ""vote_average"": 0,
                ""poster_path"": null,
                ""first_air_date"": """",
                ""popularity"": 0.6,
                ""genre_ids"": [],
                ""original_language"": ""en"",
                ""backdrop_path"": null,
                ""overview"": ""Disney Time was a television series that ran in the UK on the BBC, and also ITV at one point. It was a regular holiday schedule filler. Clips of Disney films were introduced by celebrity hosts, which over the years included Paul and Linda McCartney, Noel Edmonds, Sarah Greene, Doctor Who's Tom Baker, The Goodies and Phillip Schofield.\n\nThe following list is of programmes broadcast on BBC1. Prior to 1971, Christmas editions were always shown on Christmas Day itself."",
                ""origin_country"": []
                },
                {
                  ""original_name"": ""Disney Time"",
                  ""id"": 16612,
                  ""media_type"": ""tv"",
                  ""name"": ""Disney Time"",
                  ""vote_count"": 0,
                  ""vote_average"": 0,
                  ""poster_path"": null,
                  ""first_air_date"": """",
                  ""popularity"": 0.6,
                  ""genre_ids"": [],
                  ""original_language"": ""en"",
                  ""backdrop_path"": null,
                  ""overview"": ""Disney Time India is an hour-long TV show in India that started airing on Zee TV in 1995 and later on SET and Star Plus. Vishal Malhotra was the host but in 2004, Disney Channel India began airing instead.\n\nThe show aired from 10 am to 11 am and 6 pm to 7 pm twice a week. The morning show was called Good Morning Disney. Disney Time was previously known as Disney Hour until Star India bought out Disney India and moved the show to their two channels: STAR Plus and STAR Utsav. Disney also has four of its own channels airing in India. The show was a huge hit amongst children who had very little entertainment from original cartoons until then. They would invite letters, some of which Vishal would read out, and the lucky ones would get Disney bags, tiffin-boxes and other cool stuffs."",
                  ""origin_country"": [""IO""]
                }]
            }";

        public static string InvalidJsonBlob = @"{
            ""movie"": {
                  [],
                  ""original_name"": ""Disney Time"",
                  ""id"": 16612,
                  ""media_type"": ""tv"",
                  ""name"": ""Disney Time"",
                  ""vote_count"": 0,
                  ""vote_average"": 0,
                  ""poster_path"": null,
                  ""first_air_date"": """",
                  ""popularity"": 0.6,
                  ""genre_ids"": [],
                  ""original_language"": ""en"",
                  ""backdrop_path"": null,
                  ""overview"": ""Disney Time India is an hour-long TV show in India that started airing on Zee TV in 1995 and later on SET and Star Plus. Vishal Malhotra was the host but in 2004, Disney Channel India began airing instead.\n\nThe show aired from 10 am to 11 am and 6 pm to 7 pm twice a week. The morning show was called Good Morning Disney. Disney Time was previously known as Disney Hour until Star India bought out Disney India and moved the show to their two channels: STAR Plus and STAR Utsav. Disney also has four of its own channels airing in India. The show was a huge hit amongst children who had very little entertainment from original cartoons until then. They would invite letters, some of which Vishal would read out, and the lucky ones would get Disney bags, tiffin-boxes and other cool stuffs."",
                  ""origin_country"": [""IO""]
                }
        }";
    }
}
