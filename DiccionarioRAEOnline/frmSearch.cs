using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Web;


namespace DiccionarioRAEOnline
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
     /// 
     public enum SearchTypeEnum:byte
     {
        RAE,
        Dudas,
        Aleatoria
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
            this.ll = new System.Windows.Forms.LinkLabel();
            this.rbRAE = new System.Windows.Forms.RadioButton();
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
            this.txtSearch.Location = new System.Drawing.Point(131, 61);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(454, 26);
            this.txtSearch.TabIndex = 2;
            this.tt.SetToolTip(this.txtSearch, "Entre una sola palabra a la vez");
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Location = new System.Drawing.Point(590, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 32);
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
            this.ie.AllowWebBrowserDrop = false;
            this.ie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.er.SetIconAlignment(this.ie, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.ie.Location = new System.Drawing.Point(3, 22);
            this.ie.MinimumSize = new System.Drawing.Size(20, 20);
            this.ie.Name = "ie";
            this.ie.ScriptErrorsSuppressed = true;
            this.ie.Size = new System.Drawing.Size(751, 376);
            this.ie.TabIndex = 0;
            this.tt.SetToolTip(this.ie, "Resultados");
            this.ie.WebBrowserShortcutsEnabled = false;
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
            this.cm.Size = new System.Drawing.Size(110, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.openToolStripMenuItem.Text = "&Abrir";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.cerrarToolStripMenuItem.Text = "&Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // grp
            // 
            this.grp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp.Controls.Add(this.ie);
            this.grp.Location = new System.Drawing.Point(10, 223);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(757, 401);
            this.grp.TabIndex = 6;
            this.grp.TabStop = false;
            this.grp.Text = "Resultados";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(131, 140);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(61, 32);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<";
            this.tt.SetToolTip(this.btnBack, "Ver búsquedas anteriores");
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Location = new System.Drawing.Point(197, 140);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(60, 32);
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
            "Búsqueda de palabra exacta",
            "Búsqueda por palabras",
            "Palabras que empiezan por:",
            "Palabras que terminan en:",
            "Palabras que contienen:",
            "Anagramas",
            "Aleatoria",
            "Búsqueda sin signos diacríticos",
            "Semejanza fonético-ortográfica"});
            this.cboSearchType.Location = new System.Drawing.Point(131, 98);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(454, 28);
            this.cboSearchType.TabIndex = 3;
            // 
            // grpSearchBy
            // 
            this.grpSearchBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grpSearchBy.Location = new System.Drawing.Point(10, 17);
            this.grpSearchBy.Name = "grpSearchBy";
            this.grpSearchBy.Size = new System.Drawing.Size(757, 192);
            this.grpSearchBy.TabIndex = 0;
            this.grpSearchBy.TabStop = false;
            this.grpSearchBy.Text = "Configuración de la búsqueda";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Palabra";
            // 
            // rbDoubts
            // 
            this.rbDoubts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbDoubts.Location = new System.Drawing.Point(237, 32);
            this.rbDoubts.Name = "rbDoubts";
            this.rbDoubts.Size = new System.Drawing.Size(379, 24);
            this.rbDoubts.TabIndex = 1;
            this.rbDoubts.Text = "Diccionario panhispánico de dudas";
            this.rbDoubts.UseVisualStyleBackColor = true;
            this.rbDoubts.CheckedChanged += new System.EventHandler(this.rbDoubts_CheckedChanged);
            // 
            // ll
            // 
            this.ll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ll.AutoSize = true;
            this.ll.Location = new System.Drawing.Point(302, 145);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(166, 20);
            this.ll.TabIndex = 8;
            this.ll.TabStop = true;
            this.ll.Text = "http://www.rae.es/drae";
            this.ll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_LinkClicked);
            // 
            // rbRAE
            // 
            this.rbRAE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbRAE.AutoSize = true;
            this.rbRAE.Checked = true;
            this.rbRAE.Location = new System.Drawing.Point(66, 32);
            this.rbRAE.Name = "rbRAE";
            this.rbRAE.Size = new System.Drawing.Size(143, 24);
            this.rbRAE.TabIndex = 0;
            this.rbRAE.TabStop = true;
            this.rbRAE.Text = "Diccionario RAE";
            this.rbRAE.UseVisualStyleBackColor = true;
            // 
            // lblDirectSearch
            // 
            this.lblDirectSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDirectSearch.AutoSize = true;
            this.lblDirectSearch.Location = new System.Drawing.Point(262, 145);
            this.lblDirectSearch.Name = "lblDirectSearch";
            this.lblDirectSearch.Size = new System.Drawing.Size(46, 20);
            this.lblDirectSearch.TabIndex = 9;
            this.lblDirectSearch.Text = "URL:";
            // 
            // SearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AccessibleDescription = "Diccionarios de RAE en línea";
            this.AccessibleName = "Diccionarios de RAE en línea";
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(788, 641);
            this.Controls.Add(this.grpSearchBy);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "RAE: Consulta a sus diccionarios en línea";
            this.tt.SetToolTip(this, "RAE: Consulta a sus diccionarios en línea");
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
            if (Process.GetProcessesByName("DiccionarioRAEOnline").Length > 1)
            {
                return;
            }
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
                    if (str.IndexOf(" ", 0, str.Length) > 0)
                        return AppErrorEnum.MultipleWords;

                    string mainURL = @"http://dle.rae.es/srv/search";
                    string encStr = HttpUtility.UrlEncode(str);
                    string queryString = @"?w=" +encStr;

                    switch (cboSearchType.SelectedIndex)
                    {
                        case 0://palabra exacta
                            queryString += @"&&m=30";
                            break;
                        case 1://por palabras
                            queryString += @"&&m=form";
                            break;
                        case 2:
                            queryString += @"&&m=31";
                            break;
                        case 3:
                            queryString += @"&&m=32";
                            break;
                        case 4:
                            queryString += @"&&m=33";
                            break;
                        case 5:
                            queryString += @"&&anagram=anag";
                            break;
                        case 7:
                            mainURL = "http://lema.rae.es/drae/srv/search";
                            queryString = @"?type=1" + @"&&val=" + str;
                            break;
                        case 8:
                            mainURL = "http://lema.rae.es/drae/srv/search";
                            queryString = @"?type=2" + @"&&val=" + str;
                            break;
                        default:
                            queryString += @"&&m=form";
                            break;
                    }
                    
                   ll.Text = mainURL + queryString;
                   ie.Navigate(ll.Text);

                }
                else if (type == SearchTypeEnum.Dudas)
                {
                    ie.Navigate(@"http://lema.rae.es/dpd/srv/search?key=" + txtSearch.Text);
                }
              
                return AppErrorEnum.None;

			}
			catch (Exception ex)
			{
				Debug.Write(ex.Message);
				return AppErrorEnum.SystemError;
			}
		}
        private void CheckForError()
        {
            if (txtSearch.Text == string.Empty && !cboSearchType.Text.Contains("aleatoria"))
            {
                er.SetError(txtSearch, "Entre la palabra que desea buscar");
                return;
            }
        }
		#endregion

		#region Events
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			AppErrorEnum ae=AppErrorEnum.None;
            SearchTypeEnum type=SearchTypeEnum.RAE;

            CheckForError();

			er.SetError(txtSearch,"");

            if (rbRAE.Checked)
                type = SearchTypeEnum.RAE;
            else if (rbDoubts.Checked)
                type = SearchTypeEnum.Dudas;
            else if (cboSearchType.Text.Contains("aleatoria"))
            {
                ie.Navigate(@"http://dle.rae.es/srv/random");
                return;
            }

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
            ShowForm();
          

            cboSearchType.SelectedIndex = 0;
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
                    ll.Text = "http://www.rae.es/dpd";
               }
               else
               {
                    cboSearchType.Enabled = true;
                    tt.SetToolTip(txtSearch, "Entre una sola palabra a la vez");
                    ll.Text = "http://dle.rae.es";

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
