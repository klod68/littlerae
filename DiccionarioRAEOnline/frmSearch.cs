using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;


namespace DiccionarioRAEOnline
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
     /// 
     public enum SearchTypeEnum
     {
          RAE,
          Dudas
     }
	public class SearchForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ErrorProvider er;
        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.ToolTip tt;
        private System.ComponentModel.IContainer components;
        private WebBrowser ie;
        private GroupBox grpSearchBy;
        private ComboBox cboSearchType;
        private RadioButton rbDoubts;
        private RadioButton rbRAE;
        private ContextMenuStrip cm;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem cerrarToolStripMenuItem;
        private Label label1;
        private Label label2;
        private LinkLabel ll;
        private Label lblDirectSearch;

		private bool fromMenu = false;

		enum AppErrorEnum
		{
			None,
			NoWord,
			MultipleWords,
			SystemError
		}
		public SearchForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.er = new System.Windows.Forms.ErrorProvider(this.components);
            this.ie = new System.Windows.Forms.WebBrowser();
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grp = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.grpSearchBy = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDoubts = new System.Windows.Forms.RadioButton();
            this.rbRAE = new System.Windows.Forms.RadioButton();
            this.ll = new System.Windows.Forms.LinkLabel();
            this.lblDirectSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.er)).BeginInit();
            this.cm.SuspendLayout();
            this.grp.SuspendLayout();
            this.grpSearchBy.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(96, 74);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(567, 30);
            this.txtSearch.TabIndex = 2;
            this.tt.SetToolTip(this.txtSearch, "Entre una sola palabra a la vez");
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Location = new System.Drawing.Point(669, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 39);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Buscar";
            this.tt.SetToolTip(this.btnSearch, "Oprima para buscar");
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // er
            // 
            this.er.ContainerControl = this;
            // 
            // ie
            // 
            this.ie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.er.SetIconAlignment(this.ie, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.ie.Location = new System.Drawing.Point(3, 26);
            this.ie.MinimumSize = new System.Drawing.Size(20, 20);
            this.ie.Name = "ie";
            this.ie.Size = new System.Drawing.Size(803, 362);
            this.ie.TabIndex = 0;
            this.tt.SetToolTip(this.ie, "Resultados");
            // 
            // ni
            // 
            this.ni.ContextMenuStrip = this.cm;
            this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
            this.ni.Text = "Consulte los diccionarios de la RAE en línea";
            this.ni.Visible = true;
            this.ni.DoubleClick += new System.EventHandler(this.ni_DoubleClick);
            // 
            // cm
            // 
            this.cm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.cm.Name = "cm";
            this.cm.Size = new System.Drawing.Size(125, 56);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.openToolStripMenuItem.Text = "&Abrir";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.cerrarToolStripMenuItem.Text = "&Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // grp
            // 
            this.grp.Controls.Add(this.ie);
            this.grp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp.Location = new System.Drawing.Point(10, 286);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(809, 391);
            this.grp.TabIndex = 6;
            this.grp.TabStop = false;
            this.grp.Text = "Resultados";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(96, 169);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(76, 39);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<";
            this.tt.SetToolTip(this.btnBack, "Ver búsquedas anteriores");
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Location = new System.Drawing.Point(178, 169);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 39);
            this.btnForward.TabIndex = 2;
            this.btnForward.Text = ">";
            this.tt.SetToolTip(this.btnForward, "Ver búsquedas posteriores");
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // cboSearchType
            // 
            this.cboSearchType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboSearchType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSearchType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Items.AddRange(new object[] {
            "Búsqueda exacta",
            "Búsqueda sin signos diacríticos",
            "Semejanza fonético-ortográfica",
            "Búsqueda aproximada"});
            this.cboSearchType.Location = new System.Drawing.Point(96, 119);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(567, 33);
            this.cboSearchType.TabIndex = 3;
            // 
            // grpSearchBy
            // 
            this.grpSearchBy.Controls.Add(this.label2);
            this.grpSearchBy.Controls.Add(this.label1);
            this.grpSearchBy.Controls.Add(this.rbDoubts);
            this.grpSearchBy.Controls.Add(this.ll);
            this.grpSearchBy.Controls.Add(this.rbRAE);
            this.grpSearchBy.Controls.Add(this.lblDirectSearch);
            this.grpSearchBy.Controls.Add(this.btnForward);
            this.grpSearchBy.Controls.Add(this.txtSearch);
            this.grpSearchBy.Controls.Add(this.btnBack);
            this.grpSearchBy.Controls.Add(this.cboSearchType);
            this.grpSearchBy.Controls.Add(this.btnSearch);
            this.grpSearchBy.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearchBy.Location = new System.Drawing.Point(10, 50);
            this.grpSearchBy.Name = "grpSearchBy";
            this.grpSearchBy.Size = new System.Drawing.Size(809, 233);
            this.grpSearchBy.TabIndex = 0;
            this.grpSearchBy.TabStop = false;
            this.grpSearchBy.Text = "Configuración de la búsqueda";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Palabra";
            // 
            // rbDoubts
            // 
            this.rbDoubts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbDoubts.Location = new System.Drawing.Point(228, 39);
            this.rbDoubts.Name = "rbDoubts";
            this.rbDoubts.Size = new System.Drawing.Size(474, 29);
            this.rbDoubts.TabIndex = 1;
            this.rbDoubts.Text = "Diccionario panhispánico de dudas";
            this.rbDoubts.UseVisualStyleBackColor = true;
            this.rbDoubts.CheckedChanged += new System.EventHandler(this.rbDoubts_CheckedChanged);
            // 
            // rbRAE
            // 
            this.rbRAE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbRAE.AutoSize = true;
            this.rbRAE.Checked = true;
            this.rbRAE.Location = new System.Drawing.Point(14, 39);
            this.rbRAE.Name = "rbRAE";
            this.rbRAE.Size = new System.Drawing.Size(174, 29);
            this.rbRAE.TabIndex = 0;
            this.rbRAE.TabStop = true;
            this.rbRAE.Text = "Diccionario RAE";
            this.rbRAE.UseVisualStyleBackColor = true;
            // 
            // ll
            // 
            this.ll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ll.AutoSize = true;
            this.ll.Location = new System.Drawing.Point(455, 176);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(208, 25);
            this.ll.TabIndex = 8;
            this.ll.TabStop = true;
            this.ll.Text = "http://www.rae.es/drae";
            this.ll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_LinkClicked);
            // 
            // lblDirectSearch
            // 
            this.lblDirectSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDirectSearch.AutoSize = true;
            this.lblDirectSearch.Location = new System.Drawing.Point(259, 176);
            this.lblDirectSearch.Name = "lblDirectSearch";
            this.lblDirectSearch.Size = new System.Drawing.Size(207, 25);
            this.lblDirectSearch.TabIndex = 9;
            this.lblDirectSearch.Text = "Busque directamente: ";
            // 
            // SearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AccessibleDescription = "Diccionarios de RAE en línea";
            this.AccessibleName = "Diccionarios de RAE en línea";
            this.AutoScaleBaseSize = new System.Drawing.Size(10, 23);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(829, 687);
            this.Controls.Add(this.grpSearchBy);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.Padding = new System.Windows.Forms.Padding(10, 50, 10, 10);
            this.Text = "RAE: Consulta a sus diccionarios en línea";
            this.tt.SetToolTip(this, "RAE: Consulta a sus diccionarios en línea");
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SearchForm_Closing);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.er)).EndInit();
            this.cm.ResumeLayout(false);
            this.grp.ResumeLayout(false);
            this.grpSearchBy.ResumeLayout(false);
            this.grpSearchBy.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SearchForm());
		}
		#region Methods

		private void ShowForm()
		{		
			this.Visible=true;
			this.WindowState=FormWindowState.Normal;
               txtSearch.Focus();

		}

		private void HideForm()
		{
			try
			{		
				this.Visible=false;
			}
			catch (Exception ex)
			{
				Debug.Write(ex.Message);
			}
		}

		private AppErrorEnum SearchDefinition(string str,SearchTypeEnum type)
		{
			try
			{
                    
                    if (type == SearchTypeEnum.RAE)
                    {

                         if (str.IndexOf(" ", 0, str.Length) < 0)
                         {
                              //ie.Navigate("http://buscon.rae.es/draeI/SrvltGUIBusUsual?TIPO_HTML=2&TIPO_BUS=" + cboSearchType.SelectedIndex + "&LEMA=" + str);
                              //ie.Navigate("http://lema.rae.es/drae?type=" + cboSearchType.SelectedIndex + "&val=" + str);
                             ie.Navigate("http://lema.rae.es/drae/srv/search?type=" + cboSearchType.SelectedIndex + "&val=" + str);

                         }
                         else
                         {
                              return AppErrorEnum.MultipleWords;
                         }
                    }
                    else if (type == SearchTypeEnum.Dudas)
                    {
                         //ie.Navigate("http://buscon.rae.es/dpdI/SrvltGUIBusDPD?lema=" + txtSearch.Text);
                        ie.Navigate("http://lema.rae.es/dpd/srv/search?key=" + txtSearch.Text);

                    }
                    return AppErrorEnum.None;

			}
			catch (Exception ex)
			{
				Debug.Write(ex.Message);
				return AppErrorEnum.SystemError;
			}
		}
		#endregion

		#region Events
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			AppErrorEnum ae;
               SearchTypeEnum type=SearchTypeEnum.RAE;

               if (txtSearch.Text==string.Empty)
			{
				er.SetError(txtSearch,"Entre la palabra que desea buscar");
                    return;
			}
               else if (rbRAE.Checked)
               {
                    type = SearchTypeEnum.RAE;
               }
               else
               {
                    type=SearchTypeEnum.Dudas;
               }
		
			er.SetError(txtSearch,"");
			ae = SearchDefinition(txtSearch.Text.ToLower(),type);
			switch (ae)
			{
				case AppErrorEnum.None:
					er.SetError(txtSearch,"");
					break;
				case AppErrorEnum.MultipleWords:
					er.SetError(txtSearch,"Entre una sola palabra");
					break;
				case AppErrorEnum.NoWord:
					break;
				case AppErrorEnum.SystemError:
					er.SetError(txtSearch,"No es posible conectarse a RAE en este momento");
					break;
				default:
					er.SetError(txtSearch,"");
					break;
			}
			
               
		}

		

		private void ni_DoubleClick(object sender, System.EventArgs e)
		{
			ShowForm();
		}


		private void SearchForm_Load(object sender, System.EventArgs e)
		{
			HideForm();
               cboSearchType.SelectedIndex = 3;
		}

	
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			try
			{
				ie.GoBack();
			}
			catch
			{}
		}

		private void btnForward_Click(object sender, System.EventArgs e)
		{
			try
			{
				ie.GoForward();
			}
			catch
			{}
		}
		
		
		#endregion

		private void SearchForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!fromMenu)
			{
				e.Cancel=true;
			}
			HideForm();
		}


		protected override void WndProc(ref Message m)
		{
			const int WM_QUERYENDSESSION = 0x011;
			const int WM_ENDSESSION = 0x16;
			
			switch(m.Msg)
			{
			case WM_QUERYENDSESSION:
				fromMenu=true;
				this.Close();
				break;
			case WM_ENDSESSION:
				fromMenu=true;
				this.Close();
				break;
			}
			base.WndProc(ref m);
	     }

         
          private void rbDoubts_CheckedChanged(object sender, EventArgs e)
          {
               if (rbDoubts.Checked)
               {
                    cboSearchType.Enabled = false;
                    tt.SetToolTip(txtSearch, "Entre una palabra o frase");
                    //ll.Text = "http://buscon.rae.es/dpdI";
                    ll.Text = "http://www.rae.es/dpd";
               }
               else
               {
                    cboSearchType.Enabled = true;
                    tt.SetToolTip(txtSearch, "Entre una sola palabra a la vez");
                    //ll.Text = "http://buscon.rae.es/draeI";
                    ll.Text = "http://www.rae.es/drae";

               }
          }

          private void openToolStripMenuItem_Click(object sender, EventArgs e)
          {
               ShowForm();
          }

          private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
          
          {
               fromMenu = true;
               Application.Exit();
          }

          private void ll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               System.Diagnostics.Process.Start(ll.Text);

          }

         
       
	}
}
