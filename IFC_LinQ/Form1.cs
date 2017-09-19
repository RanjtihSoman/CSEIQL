
using System.Text;
using System.Threading.Tasks;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using System.Windows;
using System.Windows.Forms;
using System.Linq;
using System;
using System.Collections.Generic;



namespace IFC_LinQ
{
    public partial class MainPage : Form
    {
        public string file = null;
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            TreeNode node = TreeviewHierarchy .Nodes.Add("Project tree");
            TreeviewHierarchy.Update();
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
        }
        private static void PrintHierarchy(IIfcObjectDefinition o, int level,TreeNode node)
        {
            
                node.Text = o.Name;
            
            
            
            
            //only spatial elements can contain building elements
            var spatialElement = o as IIfcSpatialStructureElement;
            if (spatialElement != null)
            {
                //using IfcRelContainedInSpatialElement to get contained elements
                var containedElements = spatialElement.ContainsElements.SelectMany(rel => rel.RelatedElements);
                foreach (var element in containedElements)
                {
                    var stepchild = new TreeNode { Text = element.Name };
                    node.Nodes.Add(stepchild);
                  
                }
            }

            //using IfcRelAggregares to get spatial decomposition of spatial structure elements
            foreach (var item in o.IsDecomposedBy.SelectMany(r => r.RelatedObjects))
            {
                var child = new TreeNode() { Text = "Null"  };

                PrintHierarchy(item, level + 1, child);
                node.Nodes.Add(child);

            }
        }

        private void ButtonFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"F:\XBIM_LinQ\IFC files";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                label_openafile.Text  = file;
                using (var model = IfcStore.Open(file))
                {
                    var project = model.Instances.FirstOrDefault<IIfcProject>();
                    TreeNode node = TreeviewHierarchy.Nodes.Add("Project tree");
                    PrintHierarchy(project, 0, node);
                }
            }

        }

        private void Button_SubmitQuery_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                using (var model = IfcStore.Open(file))
                {
                    string querytext = textBox_Query.Text;
                    var queryobject = new Query(querytext,file);
                    textBox_output.Text = queryobject.output;
                    textBox_output.Update();

                }
            }
            else
            {
                displaymessagebox("Open the file before submitting query");
            }
            
        }

        void displaymessagebox(string message)
        {
           
            const string caption = "User Alert";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
            
        }

        private void textBox_Query_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label_Output_Click(object sender, EventArgs e)
        {

        }

        private void label_openafile_Click(object sender, EventArgs e)
        {

        }
    }
}
