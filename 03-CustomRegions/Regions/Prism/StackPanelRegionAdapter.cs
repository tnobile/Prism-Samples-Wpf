﻿using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace Regions
{
    /**
     * http://brianlagunas.com/create-a-custom-prism-regionadapter/
     * 
     * 
     * Prism provides 4 region adapters out of the box for you:

        ContentControlRegionAdapter
        SelectorRegionAdaptor
        ItemsControlRegionAdapter
        TabControlRegionAdapter (Silverlight only)

        Well, what happens when you want to use a different control as a region host?  Simple.  
        You need to write a custom region adapter for it.  Is it hard you ask?  
        No it is quite easy.  
        Let’s write one for the StackPanel.
     */
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }

                //handle remove
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
