using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using System.Windows;
using System.Windows.Forms;
using System.Collections;



namespace IFC_LinQ
{
    class Query
    {
        public string input;
        public string output;
        string fileName;
        IEnumerable<string> select = new List<string>();
        IEnumerable<string> from = new List<string>();
        IEnumerable<string> where = new List<string>();
        IEnumerable<string> inputlist = new List<string>();
        IEnumerable <IIfcSpatialStructureElement> spatialelementlist = new List<IIfcSpatialStructureElement>();


        public Query(string Query_from_Form,string ofilename)
        {
            output = "";
            input = Query_from_Form;
            parseinputquery();
            fileName = ofilename;
            output = querystruct()+System.Environment.NewLine ;
            process_query();
         
        }

        void process_query()
        {
            IEnumerator<string> selectenum = select.GetEnumerator();
            IEnumerator<string> fromenum = from.GetEnumerator();
            IEnumerator<string> whereenum = where.GetEnumerator();


            var model = IfcStore.Open(fileName);
            using (var txn = model.BeginTransaction())
            {
                var requiredProducts = new IIfcProduct[0]
                    .Concat(model.Instances.OfType<IIfcBuildingElement>())
                .Concat(model.Instances.OfType<IIfcSpatialElement>());



                //.Concat(model.Instances.OfType<IIfcWallStandardCase>())
                //.Concat(model.Instances.OfType<IIfcDoor>())
                //.Concat(model.Instances.OfType<IIfcWindow>());

                foreach (var o in requiredProducts)
                {
                    var spatialElement = o as IIfcSpatialStructureElement;
                    if (spatialElement != null)
                    {
                        //using IfcRelContainedInSpatialElement to get contained elements
                        var containedElements = spatialElement.ContainsElements.SelectMany(rel => rel.RelatedElements);
                        if (containedElements != null)
                        {
                            foreach (var fromvalue in select)
                            {
                                //foreach (var element2 in containedElements)
                                //output= output+ System.Environment.NewLine + string.Format("{0}    ->{1} ",  element2.Name, element2.GetType().Name);

                                var requiredelement = from element in containedElements
                                                      where element.GetType().Name.ToString() == fromvalue.ToString()
                                                      select element;
                                foreach (var element2 in requiredelement)
                                    output = output + System.Environment.NewLine + string.Format("{0}    ->{1} ", element2.GetType().Name, element2.Name);
                            }
                        }
                    }

                }


                txn.Commit();
            }


        }
                   
        public string querystruct()
        {
            string tempstring;
            tempstring = "SELECT(";
            foreach (string s in select)
                tempstring = tempstring + s + ",";
            tempstring = tempstring + ")\n WHERE (";
            foreach (string s in where)
                tempstring = tempstring + s + ",";
            tempstring = tempstring + ")\n FROM (";
            foreach (string s in from)
                tempstring = tempstring + s + ",";

            tempstring = tempstring + ")";
            return tempstring;
        }


        void parseinputquery()
               {

            char[] delimiterChars = { ' ', ',', '.', ':', '\t', ';' };
            string[] inputarray = input.Split(delimiterChars);
            foreach (string s in inputarray)
            {
                if (String.Compare(s, "") != 0)
                {
                    inputlist = inputlist.Append(s);
                }
            }
            IEnumerator<string> Inputenum = inputlist.GetEnumerator();

            if (Inputenum.MoveNext())
            {
                string tempstring = Inputenum.Current.ToString();
                string currentcase = tempstring;
                Boolean breakflag = false;
                while (Inputenum.MoveNext())
                {
                    if  (!breakflag)
                    {
                        tempstring = Inputenum.Current.ToString();
                        switch (currentcase)
                        {
                            case "select":
                                switch (tempstring)
                                {
                                    case "select":
                                        currentcase = "select";
                                        break;
                                    case "where":
                                        currentcase = "where";
                                        break;
                                    case "from":
                                        currentcase = "from";
                                        break;
                                    default:
                                        tempstring = dictionary(tempstring);
                                        select = select.Append(tempstring);
                                        break;
                                }

                                break;
                            case "where":
                                switch (tempstring)
                                {
                                    case "select":
                                        currentcase = "select";
                                        break;
                                    case "where":
                                        currentcase = "where";
                                        break;
                                    case "from":
                                        currentcase = "from";
                                        break;
                                    default:
                                        where = where.Append(tempstring);
                                        break;
                                }
                                break;
                            case "from":
                                switch (tempstring)
                                {
                                    case "select":
                                        currentcase = "select";
                                        break;
                                    case "where":
                                        currentcase = "where";
                                        break;
                                    case "from":
                                        currentcase = "from";
                                        break;
                                    default:

                                        from = from.Append(tempstring);
                                        break;
                                }
                                break;
                            default:
                                switch (currentcase)
                                {
                                    case "select":
                                        currentcase = "select";
                                        break;
                                    case "where":
                                        currentcase = "where";
                                        break;
                                    case "from":
                                        currentcase = "from";
                                        break;
                                    default:
                                        displaymessagebox("Error in the query");
                                        breakflag = true;
                                        break;
                                }

                                break;

                        }
                    }
                }
            }
        }

        string dictionary(string input)
        {
            input = input.ToLower(); ;
            Dictionary <string,string> ifc= new Dictionary<string, string>();
            ifc.Add("wall", "IfcWall");
            ifc.Add("ifcwall", "IfcWall");
            ifc.Add("walls", "IfcWall");
            ifc.Add("ifccovering", "IfcCovering");
            ifc.Add("covering", "IfcCovering");
            ifc.Add("coverings", "IfcCovering");
            ifc.Add("finishing", "IfcCovering");
            ifc.Add("finishings", "IfcCovering");
            ifc.Add("ifcdoor", "IfcDoor");
            ifc.Add("door", "IfcDoor");
            ifc.Add("doors", "IfcDoor");
            ifc.Add("ifcbeam", "IfcBeam");
            ifc.Add("beam", "IfcBeam");
            ifc.Add("beams", "IfcBeam");
            ifc.Add("ifccolumn", "IfcColumn");
            ifc.Add("column", "IfcColumn");
            ifc.Add("columns", "IfcColumn");
            ifc.Add("ifccurtainwall", "IfcCurtainWall");
            ifc.Add("curtainwall", "IfcCurtainWall");
            ifc.Add("curtainwalls", "IfcCurtainWall");
            ifc.Add("member", "IfcMember");
            ifc.Add("ifcmember", "IfcMember");
            ifc.Add("members", "IfcMember");
            ifc.Add("ifcrailing", "IfcRailing");
            ifc.Add("railing", "IfcRailing");
            ifc.Add("railings", "IfcRailing");
            ifc.Add("ifcramp", "IfcRamp");
            ifc.Add("ramp", "IfcRamp");
            ifc.Add("ramps", "IfcRamp");
            ifc.Add("ifcrampflight", "IfcRampFlight");
            ifc.Add("rampflight", "IfcRampFlight");
            ifc.Add("rampflights", "IfcRampFlight");
            ifc.Add("ifcslab", "IfcSlab");
            ifc.Add("slab", "IfcSlab");
            ifc.Add("slabs", "IfcSlab");
            ifc.Add("ifcstairflight", "IfcStairFlight");
            ifc.Add("stairflight", "IfcStairFlight");
            ifc.Add("ifcwindow", "IfcWindow");
            ifc.Add("window", "IfcWindow");
            ifc.Add("windows", "IfcWindow");
            ifc.Add("ifcstair", "IfcStair");
            ifc.Add("stair", "IfcStair");
            ifc.Add("stairs", "IfcStair");
            ifc.Add("ifcroof", "IfcRoof");
            ifc.Add("roof", "IfcRoof");
            ifc.Add("roofs", "IfcRoof");
            ifc.Add("pile", "IfcPile");
            ifc.Add("piles", "IfcPile");
            ifc.Add("ifcpile", "IfcPile");
            ifc.Add("footing", "IfcFooting");
            ifc.Add("footings", "IfcFooting");
            ifc.Add("ifcfooting", "IfcFooting");
            ifc.Add("buildingelementcomponent", "IfcBuildingElementComponent");
            ifc.Add("buildingelementcomponents", "IfcBuildingElementComponent");
            ifc.Add("ifcbuildingelementcomponent", "IfcBuildingElementComponent");
            ifc.Add("plate", "IfcPlate");
            ifc.Add("plates", "IfcPlate");
            ifc.Add("ifcplate", "IfcPlate");

            input = ifc[input];
            //exception handler to be added


            return input;
        }

        void displaymessagebox(string message)
        {

            const string caption = "User Alert";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);

        }

    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] tail)
        {
            return source.Concat(tail);
        }
    }
}

