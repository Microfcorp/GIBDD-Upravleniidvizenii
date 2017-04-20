using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    class Class1
    {
        int l;
        Form1 form;
       virtual public void func(int q)
        {
            q = l;
            form = new Form1();
           // form.funct(l);
        }
    }
}
