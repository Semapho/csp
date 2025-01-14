﻿using CSP.Events;
using CSP.Models;
using CSP.Modules.Pages.MCU.Models;
using CSP.Modules.Pages.MCU.Models.Description;
using CSP.Resources;
using CSP.Utils;
using CSP.Utils.Extensions;
using System;
using System.Collections.Generic;

namespace CSP.Modules.Pages.MCU.Tools
{
    public static class DescriptionHelper
    {
        private static readonly DescriptionInstance Instance = DescriptionInstance.Instance;

        public static ClockModel Clock { get => Instance.Clock; }

        public static string Company { get => Instance.Company; }

        public static ObservableDictionary<string, string> Defines { get => Instance.Defines; }

        public static MCUModel MCU { get => Instance.MCU; }

        public static string Name { get => Instance.Name; }

        public static PinoutModel Pinout { get => Instance.Pinout; }

        public static ObservableDictionary<string, PropertyDetails> Properties { get => Instance.Properties; }

        public static string RepositoryPath { get => Instance.RepositoryPath; }

        public static void ChangeDefine(string oldKey, string newKey, string newValue) {
            DebugUtil.Assert(!oldKey.IsNullOrEmpty() || !newKey.IsNullOrEmpty(),
                new ArgumentNullException(nameof(oldKey) + " or " + nameof(newKey)), "oldKey 或者 newKey 不能均为空");

            if (!oldKey.IsNullOrEmpty())
                if (Defines.ContainsKey(oldKey))
                    Defines.Remove(oldKey);

            if (!newKey.IsNullOrEmpty()) {
                if (Defines.ContainsKey(newKey))
                    Defines.Remove(newKey);

                Defines.Add(newKey, newValue);
            }
        }

        public static IPModel GetIP(string name) {
            return Instance.GetIP(name.ToUpper());
        }

        public static MapModel GetMap(string name) {
            return Instance.GetMap(name.ToUpper());
        }

        public static PinModel GetPinProperty(string name) {
            return Instance.GetPinProperty(name);
        }

        public static bool IsDependence(IEnumerable<string> dependencies) {
            if (dependencies == null)
                return true;

            bool isDependence = true;
            foreach (var dependence in dependencies) {
                if (!Defines.ContainsKey(dependence))
                    isDependence = false;
            }

            return isDependence;
        }

        public static bool Load(MCUModel mcu) {
            DebugUtil.Assert(mcu != null, new ArgumentNullException(nameof(mcu)), "MCU不能为空");
            if (mcu == null)
                return false;

            Instance.MCU = mcu;

            return true;
        }

        public static bool Load(string company, string name) {
            DebugUtil.Assert(!company.IsNullOrEmpty(), new ArgumentNullException(nameof(company)), "company不能为空");
            DebugUtil.Assert(!name.IsNullOrEmpty(), new ArgumentNullException(nameof(name)), "name不能为空");
            if (company == null || name == null)
                return false;

            return Load(MCUModel.Load($"{IniFile.PathMCUDb}/{company}/{name}.xml"));
        }
    }
}