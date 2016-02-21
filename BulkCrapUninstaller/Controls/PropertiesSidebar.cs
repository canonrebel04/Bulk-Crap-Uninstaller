﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BulkCrapUninstaller.Properties;
using Klocman.Binding;

namespace BulkCrapUninstaller.Controls
{
    public partial class PropertiesSidebar : UserControl
    {
        private readonly SettingBinder<Settings> _settings = Settings.Default.SettingBinder;

        public PropertiesSidebar()
        {
            InitializeComponent();

            _settings.BindControl(checkBoxViewCheckboxes, x => x.UninstallerListUseCheckboxes, this);
            _settings.BindControl(checkBoxViewGroups, x => x.UninstallerListUseGroups, this);

            _settings.BindControl(checkBoxListHideMicrosoft, x => x.FilterHideMicrosoft, this);
            _settings.BindControl(checkBoxShowUpdates, x => x.FilterShowUpdates, this);
            _settings.BindControl(checkBoxListSysComp, x => x.FilterShowSystemComponents, this);
            _settings.BindControl(checkBoxListProtected, x => x.FilterShowProtected, this);
            _settings.BindControl(checkBoxShowStoreApps, x => x.FilterShowStoreApps, this);

            _settings.BindControl(checkBoxInvalidTest, x => x.AdvancedTestInvalid, this);
            _settings.BindControl(checkBoxCertTest, x => x.AdvancedTestCertificates, this);
            _settings.BindControl(checkBoxOrphans, x => x.AdvancedDisplayOrphans, this);

            _settings.SendUpdates(this);
            Disposed += (x, y) => _settings.RemoveHandlers(this);
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool SysCompEnabled
        {
            get { return checkBoxListSysComp.Enabled; }
            set { checkBoxListSysComp.Enabled = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool ProtectedEnabled
        {
            get { return checkBoxListProtected.Enabled; }
            set { checkBoxListProtected.Enabled = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool UpdatesEnabled
        {
            get { return checkBoxShowUpdates.Enabled; }
            set { checkBoxShowUpdates.Enabled = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrphansEnabled
        {
            get { return checkBoxOrphans.Enabled; }
            set { checkBoxOrphans.Enabled = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool StoreAppsEnabled
        {
            get { return checkBoxShowStoreApps.Enabled; }
            set { checkBoxShowStoreApps.Enabled = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool InvalidEnabled
        {
            get { return checkBoxInvalidTest.Enabled; }
            set { checkBoxInvalidTest.Enabled = value; }
        }
    }
}