﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowser.Examples.ListView.BindableCollections.GroupDescriptors
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<GroupDescriptorBase> groupDescriptors;
        private bool isPropertyNameGroupSwitchToggled;
        private bool isSortOrderGroupSwitchToggled;
        private List<Event> items;

        public ViewModel()
        {
            this.Items = this.GetItems();
            this.groupDescriptors = new ObservableCollection<GroupDescriptorBase>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<GroupDescriptorBase> GroupDescriptors
        {
            get
            {
                return this.groupDescriptors;
            }
            set
            {
                if (this.groupDescriptors != value)
                {
                    this.groupDescriptors = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsPropertyNameGroupSwitchToggled
        {
            get
            {
                return this.isPropertyNameGroupSwitchToggled;
            }
            set
            {
                if (this.isPropertyNameGroupSwitchToggled != value)
                {
                    this.isPropertyNameGroupSwitchToggled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSortOrderGroupSwitchToggled
        {
            get
            {
                return this.isSortOrderGroupSwitchToggled;
            }
            set
            {
                if (this.isSortOrderGroupSwitchToggled != value)
                {
                    this.isSortOrderGroupSwitchToggled = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Event> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                if (this.items != value)
                {
                    this.items = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<Event> GetItems()
        {
            var results = new List<Event>();

            results.Add(new Event() { Content = "Content of the item", Day = "Tommorow", Category = "A" });
            results.Add(new Event() { Content = "This also happens today", Day = "Yesterday", Category = "A" });
            results.Add(new Event() { Content = "More events today", Day = "Today", Category = "A" });
            results.Add(new Event() { Content = "Go shopping after 19:00", Day = "Yesterday", Category = "B" });
            results.Add(new Event() { Content = "You are now free to do whathever", Day = "Today", Category = "B" });

            results.Add(new Event() { Content = "For tommorow", Day = "Today", Category = "B" });
            results.Add(new Event() { Content = "It is a free day", Day = "Yesterday", Category = "C" });
            results.Add(new Event() { Content = "Go have some fun", Day = "Tommorow", Category = "C" });
            results.Add(new Event() { Content = "Party", Day = "Tommorow", Category = "C" });

            return results;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.UpdateExistingGroupDescriptor(propertyName);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateExistingGroupDescriptor(string propertyToUpdate)
        {
            if (this.GroupDescriptors == null)
                return;
            
            if (this.GroupDescriptors.Count == 0)
            {
                this.GroupDescriptors.Add(new PropertyGroupDescriptor()
                {
                    PropertyName = "Day",
                    SortOrder = SortOrder.Ascending
                });
            }

            if (propertyToUpdate.Equals(nameof(IsSortOrderGroupSwitchToggled)))
            {
                var descriptor = (PropertyGroupDescriptor)this.GroupDescriptors.FirstOrDefault();
                descriptor.SortOrder = isSortOrderGroupSwitchToggled ? SortOrder.Descending : SortOrder.Ascending;
            }
            else if (propertyToUpdate.Equals(nameof(IsPropertyNameGroupSwitchToggled)))
            {
                var descriptor = (PropertyGroupDescriptor)this.GroupDescriptors.FirstOrDefault();
                descriptor.PropertyName = isPropertyNameGroupSwitchToggled ? "Category" : "Day";
            }
        }
    }
}