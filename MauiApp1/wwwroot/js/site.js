window.dropdownHelper = {
    registerOutsideClick: function (dropdownElementId, dotNetHelper) {
        function onClick(event) {
            const dropdown = document.getElementById(dropdownElementId);
            if (dropdown && !dropdown.contains(event.target)) {
                dotNetHelper.invokeMethodAsync("CloseDropdown");
                document.removeEventListener("click", onClick); // Remove listener once handled
            }
        }

        // Give time for the next tick to avoid immediate close
        setTimeout(() => {
            document.addEventListener("click", onClick);
        }, 0);
    }
};
