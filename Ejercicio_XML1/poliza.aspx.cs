using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Ejercicio_XML1
{
    public partial class poliza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPoliza_Click(object sender, EventArgs e)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", null));
            XElement nodoRaiz = new XElement("polizas");
            document.Add(nodoRaiz);
            XElement nodo = new XElement("poliza");
            nodoRaiz.Add(nodo);
            XElement cotizacion = new XElement("cotizacion");
            cotizacion.Add(new XElement("IdCotizacion", txtNoCotizacion.Text));
            cotizacion.Add(new XElement("Agencia", txtAgencia.Text));
            cotizacion.Add(new XElement("FechaCotizacion", txtFechaCotizacion.Text));
            nodo.Add(cotizacion);

            XElement cliente = new XElement("cliente");
            cliente.Add(new XElement("Asegurado", txtNombreAsegurado.Text));
            cliente.Add(new XElement("RFC", txtRFC.Text));
            cliente.Add(new XElement("Telefono", txtTelefono.Text));
            nodo.Add(cliente);

            XElement vehiculo = new XElement("vehiculo");
            vehiculo.Add(new XElement("Marca", txtMarca.Text));
            vehiculo.Add(new XElement("Modelo", txtModelo.Text));
            vehiculo.Add(new XElement("Serie", txtNumSerie.Text));
            vehiculo.Add(new XElement("Motor", txtNumMotor.Text));
            nodo.Add(vehiculo);
            document.Save(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
            lblMensaje.Text = "XML generado";
        }

        protected void btnLeer_Click(object sender, EventArgs e)
        {
            XDocument xmlPoliza = XDocument.Load(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
         
            var poli = from cot in xmlPoliza.Descendants("poliza") select cot;
            foreach(XElement co in poli.Elements("cotizacion"))
            {
                Label1.Text = "IdCotizacion=" + co.Element("IdCotizacion").Value+" Agencia=" + co.Element("Agencia").Value+" Fecha=" + co.Element("FechaCotizacion").Value;
            }

            foreach (XElement co in poli.Elements("cliente"))
            {
                Label2.Text = "Nombre Asegurado=" + co.Element("Asegurado").Value + " RFC=" + co.Element("RFC").Value + " Telefono=" + co.Element("Telefono").Value;
            }

            foreach (XElement co in poli.Elements("vehiculo"))
            {
                Label3.Text = "Marca=" + co.Element("Marca").Value + " Modelo=" + co.Element("Modelo").Value + " Serie=" + co.Element("Serie").Value + " Motor=" + co.Element("Motor").Value;
            }
        }

        protected void btnllenar_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
            var result = from elemento in document.Descendants("poliza")
                         select new
                         {

                             IdCotizacion = elemento.Element("cotizacion").Element("IdCotizacion").Value,
                             Agencia = elemento.Element("cotizacion").Element("Agencia").Value,
                             FechaCotizacion = elemento.Element("cotizacion").Element("FechaCotizacion").Value,
                             Asegurado = elemento.Element("cliente").Element("Asegurado").Value,
                             RFC = elemento.Element("cliente").Element("RFC").Value,
                             Telefono = elemento.Element("cliente").Element("Telefono").Value,
                             Marca = elemento.Element("vehiculo").Element("Marca").Value,
                             Modelo = elemento.Element("vehiculo").Element("Modelo").Value,
                             Serie = elemento.Element("vehiculo").Element("Serie").Value,
                             Motor = elemento.Element("vehiculo").Element("Motor").Value

                         };
            dgvTablaPolizas.DataSource = result;
            dgvTablaPolizas.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
            XElement nodo = new XElement("poliza");
            document.Root.Add(nodo);

            XElement cotizacion = new XElement("cotizacion");
            cotizacion.Add(new XElement("IdCotizacion", txtNoCotizacion.Text));
            cotizacion.Add(new XElement("Agencia", txtAgencia.Text));
            cotizacion.Add(new XElement("FechaCotizacion", txtFechaCotizacion.Text));
            nodo.Add(cotizacion);

            XElement cliente = new XElement("cliente");
            cliente.Add(new XElement("Asegurado", txtNombreAsegurado.Text));
            cliente.Add(new XElement("RFC", txtRFC.Text));
            cliente.Add(new XElement("Telefono", txtTelefono.Text));
            nodo.Add(cliente);

            XElement vehiculo = new XElement("vehiculo");
            vehiculo.Add(new XElement("Marca", txtMarca.Text));
            vehiculo.Add(new XElement("Modelo", txtModelo.Text));
            vehiculo.Add(new XElement("Serie", txtNumSerie.Text));
            vehiculo.Add(new XElement("Motor", txtNumMotor.Text));
            nodo.Add(vehiculo);
            document.Save(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
            lblMensaje.Text = "XML Agregado";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
            var result = from elemento in document.Descendants("poliza")
                         select new
                         {

                             IdCotizacion = elemento.Element("cotizacion").Element("IdCotizacion").Value,
                             Agencia = elemento.Element("cotizacion").Element("Agencia").Value,
                             FechaCotizacion = elemento.Element("cotizacion").Element("FechaCotizacion").Value,
                             Asegurado = elemento.Element("cliente").Element("Asegurado").Value,
                             RFC = elemento.Element("cliente").Element("RFC").Value,
                             Telefono = elemento.Element("cliente").Element("Telefono").Value,
                             Marca = elemento.Element("vehiculo").Element("Marca").Value,
                             Modelo = elemento.Element("vehiculo").Element("Modelo").Value,
                             Serie = elemento.Element("vehiculo").Element("Serie").Value,
                             Motor = elemento.Element("vehiculo").Element("Motor").Value

                         };
            var result2 = result.ToList();
            for(int i=0; i < result2.Count; i++)
            {
                if (!result2[i].IdCotizacion.Equals(txtIdBuscar.Text))
                {
                    result2.RemoveAt(i);
                }
            }
            dgvTablaPolizas.DataSource = result2;
            dgvTablaPolizas.DataBind();

            txtNoCotizacion.Text = result2[0].IdCotizacion;
            txtAgencia.Text = result2[0].Agencia;
            txtFechaCotizacion.Text = result2[0].FechaCotizacion;

            txtNombreAsegurado.Text = result2[0].Asegurado;
            txtRFC.Text = result2[0].RFC;
            txtTelefono.Text = result2[0].Telefono;

            txtMarca.Text = result2[0].Marca;
            txtModelo.Text = result2[0].Modelo;
            txtNumSerie.Text = result2[0].Serie;
            txtNumMotor.Text = result2[0].Motor;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
            var result = from elemento in document.Descendants("poliza")
                         select new
                         {

                             IdCotizacion = elemento.Element("cotizacion").Element("IdCotizacion").Value,
                             Agencia = elemento.Element("cotizacion").Element("Agencia").Value,
                             FechaCotizacion = elemento.Element("cotizacion").Element("FechaCotizacion").Value,
                             Asegurado = elemento.Element("cliente").Element("Asegurado").Value,
                             RFC = elemento.Element("cliente").Element("RFC").Value,
                             Telefono = elemento.Element("cliente").Element("Telefono").Value,
                             Marca = elemento.Element("vehiculo").Element("Marca").Value,
                             Modelo = elemento.Element("vehiculo").Element("Modelo").Value,
                             Serie = elemento.Element("vehiculo").Element("Serie").Value,
                             Motor = elemento.Element("vehiculo").Element("Motor").Value

                         };
            var result2 = result.ToList();
            for (int i = 0; i < result2.Count; i++)
            {
                if (result2[i].IdCotizacion.Equals(txtIdEliminar.Text))
                {
                    result2.RemoveAt(i);
                    break;
                }
            }

            XDocument document_nuevo = new XDocument(new XDeclaration("1.0", "utf-8", null));
            XElement nodoRaiz = new XElement("polizas");
            document_nuevo.Add(nodoRaiz);

            for(int i=0; i<result2.Count; i++)
            {
                XElement nodo = new XElement("poliza");
                nodoRaiz.Add(nodo);
                XElement cotizacion = new XElement("cotizacion");
                cotizacion.Add(new XElement("IdCotizacion", result2[i].IdCotizacion));
                cotizacion.Add(new XElement("Agencia", result2[i].Agencia));
                cotizacion.Add(new XElement("FechaCotizacion", result2[i].FechaCotizacion));
                nodo.Add(cotizacion);

                XElement cliente = new XElement("cliente");
                cliente.Add(new XElement("Asegurado", result2[i].Asegurado));
                cliente.Add(new XElement("RFC", result2[i].RFC));
                cliente.Add(new XElement("Telefono", result2[i].Telefono));
                nodo.Add(cliente);

                XElement vehiculo = new XElement("vehiculo");
                vehiculo.Add(new XElement("Marca", result2[i].Marca));
                vehiculo.Add(new XElement("Modelo", result2[i].Modelo));
                vehiculo.Add(new XElement("Serie", result2[i].Serie));
                vehiculo.Add(new XElement("Motor", result2[i].Motor));
                nodo.Add(vehiculo);
            }
            document_nuevo.Save(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
            lblMensaje.Text = "XML generado";
            dgvTablaPolizas.DataSource = result2;
            dgvTablaPolizas.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNoCotizacion.Text = "";
            txtAgencia.Text = "";
            txtFechaCotizacion.Text = "";

            txtNombreAsegurado.Text = "";
            txtRFC.Text = "";
            txtTelefono.Text = "";

            txtMarca.Text = "";
            txtModelo.Text = "";
            txtNumSerie.Text = "";
            txtNumMotor.Text = "";
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");

            XmlNode node;
            node = doc.DocumentElement;

            foreach (XmlNode node1 in node.ChildNodes)
            {
                if (node1.ChildNodes[0].ChildNodes[0].InnerText.Equals(txtNoCotizacion.Text))
                {
                    node1.ChildNodes[0].ChildNodes[1].InnerText = txtAgencia.Text;
                    node1.ChildNodes[0].ChildNodes[2].InnerText = txtFechaCotizacion.Text;
                    node1.ChildNodes[1].ChildNodes[0].InnerText = txtNombreAsegurado.Text;
                    node1.ChildNodes[1].ChildNodes[1].InnerText = txtRFC.Text;
                    node1.ChildNodes[1].ChildNodes[2].InnerText = txtTelefono.Text;
                    node1.ChildNodes[2].ChildNodes[0].InnerText = txtMarca.Text;
                    node1.ChildNodes[2].ChildNodes[1].InnerText = txtModelo.Text;
                    node1.ChildNodes[2].ChildNodes[2].InnerText = txtNumSerie.Text;
                    node1.ChildNodes[2].ChildNodes[3].InnerText = txtNumMotor.Text;
                    doc.Save(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
                    break;
                }
            }

            XDocument document = XDocument.Load(@"C:\Users\Jesus Ramirez Ayala\Desktop\poliza.xml");
            var result = from elemento in document.Descendants("poliza")
                         select new
                         {

                             IdCotizacion = elemento.Element("cotizacion").Element("IdCotizacion").Value,
                             Agencia = elemento.Element("cotizacion").Element("Agencia").Value,
                             FechaCotizacion = elemento.Element("cotizacion").Element("FechaCotizacion").Value,
                             Asegurado = elemento.Element("cliente").Element("Asegurado").Value,
                             RFC = elemento.Element("cliente").Element("RFC").Value,
                             Telefono = elemento.Element("cliente").Element("Telefono").Value,
                             Marca = elemento.Element("vehiculo").Element("Marca").Value,
                             Modelo = elemento.Element("vehiculo").Element("Modelo").Value,
                             Serie = elemento.Element("vehiculo").Element("Serie").Value,
                             Motor = elemento.Element("vehiculo").Element("Motor").Value

                         };
            dgvTablaPolizas.DataSource = result;
            dgvTablaPolizas.DataBind();

        }
    }
}