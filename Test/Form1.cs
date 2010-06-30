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
            //ʵ����   
            Stack myStack = new Stack();   
            //ʹ��Push������ջ   
            myStack.Push("A");   
            myStack.Push("B");   
            myStack.Push("C");
            myStack.Push("C");

           
            //����ջԪ��   
            Console.WriteLine("\nmyStack:");   
            foreach (string item in myStack)   
            {   
                Console.WriteLine("|_" + item);   
            }   
  
            //ʹ��Pop������ջ   
            Console.WriteLine("\nItem pulled from myStack: " + myStack.Pop().ToString());   
            Console.WriteLine("\nAfter myStack.Pop(),myStack:");   
            foreach (string item in myStack)   
            {   
                Console.WriteLine("|_" + item);   
            }   
  
            //Peek����ֻ����ջ��Ԫ�أ�����ջ��ɾ��   
            Console.WriteLine("\nmyStack.Peek() : " + myStack.Peek().ToString());   
            Console.WriteLine("\nAfter myStack.Peek(),myStack:");   
            foreach (string item in myStack)   
            {   
                Console.WriteLine("|_" + item);   
            }   
        }
    }
}