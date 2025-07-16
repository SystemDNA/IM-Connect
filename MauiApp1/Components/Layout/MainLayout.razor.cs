// File: Components/Layout/MainLayout.razor.cs
using Microsoft.AspNetCore.Components;

namespace MauiApp1.Components.Layout // Make sure this is correct
{
    public partial class MainLayout : LayoutComponentBase
    {
        protected bool AddTopSpacing { get; private set; } = true;
        protected bool AddBottomSpacing { get; private set; } = true;

        public void SetPageSpacing(bool top, bool bottom)
        {
            AddTopSpacing = top;
            AddBottomSpacing = bottom;
            StateHasChanged();
        }

        protected string MainContentClass =>
            $"page-content{(AddTopSpacing ? " space-top" : "")}{(AddBottomSpacing ? " space-bottom" : "")}";
    }
}
