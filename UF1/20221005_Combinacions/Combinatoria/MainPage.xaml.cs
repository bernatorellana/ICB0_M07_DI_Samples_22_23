kground_color</item>
    <item name="itemTextColor">@color/m3_navigation_item_text_color</item>
    <item name="topInsetScrimEnabled">false</item>
    <item name="bottomInsetScrimEnabled">false</item>
    <item name="dividerInsetStart">@dimen/m3_navigation_menu_divider_horizontal_padding</item>
    <item name="dividerInsetEnd">@dimen/m3_navigation_menu_divider_horizontal_padding</item>
    <item name="subheaderInsetStart">@dimen/m3_navigation_menu_headline_horizontal_padding</item>
    <item name="subheaderInsetEnd">@dimen/m3_navigation_menu_headline_horizontal_padding</item>
    <item name="drawerLayoutCornerSize">@dimen/m3_navigation_drawer_layout_corner_size</item>
  </style>
    <style name="Widget.Material3.PopupMenu" parent="Widget.MaterialComponents.PopupMenu">
    <item name="android:popupElevation" ns1:ignore="NewApi">@dimen/m3_menu_elevation</item>
  </style>
    <style name="Widget.Material3.PopupMenu.ContextMenu" parent="Widget.MaterialComponents.PopupMenu.ContextMenu">
    <item name="android:popupElevation" ns1:ignore="NewApi">@dimen/m3_menu_elevation</item>
  </style>
    <style name="Widget.Material3.PopupMenu.ListPopupWindow" parent="Widget.MaterialComponents.PopupMenu.ListPopupWindow">
    <item name="android:popupElevation" ns1:ignore="NewApi">@dimen/m3_menu_elevation</item>
  </style>
    <style name="Widget.Material3.PopupMenu.Overflow" parent="Widget.MaterialComponents.PopupMenu.Overflow">
    <item name="android:popupElevation" ns1:ignore="NewApi">@dimen/m3_menu_elevation</item>
  </style>
    <style name="Widget.Material3.Slider" parent="Widget.MaterialComponents.Slider">
    <item name="haloColor">@color/m3_slider_halo_color</item>
    <item name="labelStyle">@style/Widget.Material3.Tooltip</item>
    <item name="thumbColor">@color/m3_slider_thumb_color</item>
    <item name="tickColorActive">@color/m3_slider_inactive_track_color</item>
    <item name="tickColorInactive">@color/m3_slider_active_track_color</item>
    <item name="trackColorActive">@color/m3_slider_active_track_color</item>
    <item name="trackColorInactive">@color/m3_slider_inactive_track_color</item>
    <item name="thumbElevation">@dimen/m3_slider_thumb_elevation</item>
  </style>
    <style name="Widget.Material3.Snackbar" parent="Base.Widget.Material3.Snackbar">
    <!-- Null out the background here so the programmatically