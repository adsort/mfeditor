using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Collections.Specialized;

using FusionMap.Geodatabase;
using FusionMap.DataSourcesFile;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pWsf = new ShapefileWorkspaceFactory();
            IWorkspace pWs = pWsf.OpenFromFile("",0);
            IFeatureWorkspace pFws = pWs as IFeatureWorkspace;
            IFeatureClass pFc = pFws.OpenFeatureClass("");


            //pWs = new WorkspaceClass();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //实例化   
            Stack myStack = new Stack();   
            //使用Push方法入栈   
            myStack.Push("A");   
            myStack.Push("B");   
            myStack.Push("C");
            myStack.Push("C");

           
            //遍历栈元素   
            Console.WriteLine("\nmyStack:");   
            foreach (string item in myStack)   
            {   
                Console.WriteLine("|_" + item);   
            }   
  
            //使用Pop方法出栈   
            Console.WriteLine("\nItem pulled from myStack: " + myStack.Pop().ToString());   
            Console.WriteLine("\nAfter myStack.Pop(),myStack:");   
            foreach (string item in myStack)   
            {   
                Console.WriteLine("|_" + item);   
            }   
  
            //Peek方法只返回栈顶元素，不从栈中删除   
            Console.WriteLine("\nmyStack.Peek() : " + myStack.Peek().ToString());   
            Console.WriteLine("\nAfter myStack.Peek(),myStack:");   
            foreach (string item in myStack)   
            {   
                Console.WriteLine("|_" + item);   
            }   
        }
    }
}