using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPetShop.Helper
{

    public class ConversorHelper
    {
        public DateTime? convertToDate(string date)
        {

            DateTime? DateToDatetime;
            try
            {
                if (date == "__:__")
                {
                    date = "";
                }
                if (!String.IsNullOrEmpty(date))
                {
                    System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-AR", false);

                    DateToDatetime = System.DateTime.ParseExact(date, "dd/MM/yyyy", MiFp);
                }
                else
                {
                    DateToDatetime = null;
                }
                return DateToDatetime;

            }
            catch (Exception)
            {
                return null;
            }

        }

        public String convertStringToDate(DateTime? date)
        {
            String DateToString;
            try
            {
                if (date != null)
                {
                    DateToString = ((DateTime)date).ToString("dd/MM/yyyy");
                }
                else
                {
                    DateToString = " ";
                }
                return DateToString;

            }
            catch (Exception)
            {
                return "error";
            }

        }

        public String convertStringToDateTime(DateTime? date)
        {
            String DateToString;
            try
            {
                if (date != null)
                {
                    DateToString = ((DateTime)date).ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    DateToString = " ";
                }
                return DateToString;

            }
            catch (Exception)
            {
                return "error";
            }

        }
        // convierte un Datetime a un String para pasarselo al modelo
        public String convertHourToString(DateTime? date)
        {
            String DateToString;
            try
            {
                if (date != null)
                {
                    DateToString = ((DateTime)date).ToString("HH:mm");
                }
                else
                {
                    DateToString = " ";
                }
                return DateToString;

            }
            catch (Exception)
            {
                return "error";
            }

        }
        // convierte a formato hora 
        public String convertToLocalHour(DateTime? date)
        {
            String DateToString;
            try
            {
                if (date != null)
                {
                    DateToString = ((DateTime)date).ToString("HH:mm");
                }
                else
                {
                    DateToString = " ";
                }
                return DateToString;

            }
            catch (Exception)
            {
                return "error";
            }

        }
        // convierte un String HORA a datetime para guardar en la BD 
        public DateTime? convertToDatetime(String date)
        {
            DateTime? DateToDatetime;
            try
            {
                if (date == "__:__")
                {
                    date = "";
                }
                if (!String.IsNullOrEmpty(date))
                {
                    System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-AR", false);
                    String DateOld = "01/01/1990 ";
                    DateOld += date;
                    DateToDatetime = System.DateTime.ParseExact(DateOld, "dd/MM/yyyy HH:mm", MiFp);
                }
                else
                {
                    DateToDatetime = null;
                }
                return DateToDatetime;

            }
            catch (Exception)
            {
                return null;
            }
        }

        // convierte a formato hora, (Control cambio de UTC a local)
        //public String convertToLocalHour(DateTime HourUpdate, DateTime dateSolo)
        //{

        //   try
        //    {
        //        DateTime topTime;
        //        DateTime botTime;

        //        //-- Buscar la configuración de las fechas 

        //        Core.SqlDataAccess.LivePmiModelDataContext model = new SqlDataAccess.LivePmiModelDataContext();

        //        var resultsUTC = from p in model.UTC
        //                         select p;
        //        if (resultsUTC.Count() == 1)
        //        {
        //            var result = resultsUTC.First();
        //            topTime = (DateTime)result.TopTime;
        //            botTime = (DateTime)result.BotTime;

        //            //-- Componer la fecha completa. Basándonos en los campos @date_solo @STA
        //            //set @FechaCompleta = dateadd(mi,datepart(mi,@STA), dateadd(hh, datepart(hh,@STA), dbo.DATEVALUE(@date_solo)))


        //            DateTime fechaCompleta = new DateTime(dateSolo.Year, dateSolo.Month, dateSolo.Day, HourUpdate.Hour, HourUpdate.Minute, HourUpdate.Second);

        //            //-- Ahora agregamos horas de acuerdo a la configuración de la tabla UTC y el momento
        //            //-- en el cual se produzca el vuelo.

        //            if (fechaCompleta <= botTime && fechaCompleta >= topTime)
        //            {
        //                fechaCompleta = fechaCompleta.AddHours(2);
        //            }
        //            else
        //            {
        //                fechaCompleta = fechaCompleta.AddHours(1);
        //            }

        //          return (fechaCompleta).ToString("HH:mm");
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //    catch (Exception )
        //    {
        //        return null;
        //    }

        //}
        // convierte de entero a boleano (0 = false, 1= true) 
        public bool convertIntToBool(int? campoBD)
        {
            if (campoBD == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // convierte de booleano a entero para guardar en la BD  (false = 0 , true = 1) 
        public int convertBoolToInt(bool campoBD)
        {
            if (campoBD == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        // convierte un campo de la BD (Double) en 0, en el caso de que sea NULL 
        public double convertNulltoCero(double? number)
        {
            if (number == null)
            {
                return 0;
            }
            else
            {
                return (double)number;
            }
        }
        //convierte un campo de la BD (String) en " " en el caso que sea NULL
        public string convertNulltoEmpty(string campoBD)
        {

            var res = campoBD;
            if (campoBD == null)
            {
                res = "";
            }
            return res;
        }


        public byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}