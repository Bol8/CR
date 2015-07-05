using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CR.Entities;

namespace CR.Management
{
    public class Management
    {

        private static ContractsRecollectEntities db = new ContractsRecollectEntities();



    public static bool checkTypeofData(BaseFieldsTemplate template){

        var Type = db.BaseFieldTypes.Find(template.idContractFieldTypes);


        switch (Type.Type1.Name.Trim())
        {

            case "int":

                int aux;

                if (int.TryParse(template.FieldValue, out aux)) return true;
                else return false;



            case "long":

                long l;

                if (long.TryParse(template.FieldValue, out l)) return true;
                else return false;



            case "float":

                float f;

                if (float.TryParse(template.FieldValue, out f)) return true;
                else return false;


            case "double":

                double d;

                if (double.TryParse(template.FieldValue, out d)) return true;
                else return false;


            case "date":

                DateTime dateValue;

                if (DateTime.TryParse(template.FieldValue, out dateValue)) return true;
                else return false;


            case "string":



                break;



        }


        return true;
    }




    }
}