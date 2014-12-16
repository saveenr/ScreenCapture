using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ScreenCaptureLib.Interop;

namespace ScreenCaptureLib
{
    public static class DrawingUtil
    {
        /// <summary>
        /// Creates a new bitmap from a specific region of another bitmap
        /// </summary>
        /// <param name="bmp_source"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static Bitmap CopyBitmap(Bitmap bmp_source, Rectangle region)
        {
            var bmp_dest = new Bitmap(region.Width, region.Height);
            using (var g = Graphics.FromImage(bmp_dest))
            {
                g.DrawImage(bmp_source, 0, 0, region, GraphicsUnit.Pixel);
            }
            return bmp_dest;
        }

        /// <summary>
        /// Capture a region of a screen into a bitmap
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        /// <param name="pixformat"></param>
        /// <param name="capture_mouse"></param>
        /// <returns></returns>
        public static Bitmap CaptureScreen(Screen screen, Rectangle rect, PixelFormat pixformat, bool capture_mouse)
        {
            var dest_bitmap = new Bitmap(rect.Width, rect.Height, pixformat);

            using (var graphics = Graphics.FromImage(dest_bitmap))
            {
                var dest_pos = new Point(0, 0);
                graphics.CopyFromScreen(rect.X, rect.Y, dest_pos.X, dest_pos.Y, rect.Size);
                if (capture_mouse)
                {
                    draw_mouse_pointer(dest_bitmap, graphics);
                }
            }
            return dest_bitmap;
        }

        private static void draw_mouse_pointer(Bitmap screen_bitmap, Graphics graphics)
        {
            // Fill the cursor info struct
            var cursor_info = User32.GetCursorInfo();

            // Check if the cursor is visible
            if (cursor_info.flags != WinConst.CURSOR_SHOWING)
            {
                // it is not visible - do nothing
                return;
            }

            // Retrieve the icon being used for the cursor
            using (var icon_handle = User32.CopyIcon(cursor_info.hCursor))
            {
                var iconinfo = User32.GetIconInfo(icon_handle);

                int icon_left = cursor_info.ptScreenPos.x - iconinfo.xHotspot;
                int icon_top = cursor_info.ptScreenPos.y - iconinfo.yHotspot;

                try
                {
                    using (var icon = Icon.FromHandle(icon_handle.DangerousGetHandle()))
                    {
                        if ((iconinfo.hbmColor != IntPtr.Zero))
                        {
                            // this is a "normal" bitmap so just draw the icon
                            graphics.DrawIcon(icon, icon_left, icon_top);
                        }
                        else if ((iconinfo.hbmColor == IntPtr.Zero) && (iconinfo.hbmMask != IntPtr.Zero))
                        {
                            // or draw the mask manually
                            using (var bmp_mask = Bitmap.FromHbitmap(iconinfo.hbmMask))
                            {
                                if (bmp_mask.Height != icon.Height * 2)
                                {
                                    throw new Exception("mask does not have expected height - should be twice the icon height");
                                }

                                var r2 = new Rectangle(icon_left, icon_top, icon.Width, icon.Height);
                                using (var bmp_temp = DrawingUtil.CopyBitmap(screen_bitmap, r2))
                                {
                                    for (int x = 0; x < icon.Width; x++)
                                    {
                                        for (int y = 0; y < icon.Height; y++)
                                        {
                                            var mask_color = bmp_mask.GetPixel(x, y);
                                            if (mask_color.R == 0)
                                            {
                                                var final_color = mask_color;
                                                bmp_temp.SetPixel(x, y, final_color);
                                            }
                                        }
                                    }


                                    for (int x = 0; x < icon.Width; x++)
                                    {
                                        for (int y = 0; y < icon.Height; y++)
                                        {
                                            var original_screen_color = bmp_temp.GetPixel(x, y);
                                            var mask_color = bmp_mask.GetPixel(x, y + icon.Height);
                                            if (mask_color.R != 0)
                                            {
                                                int new_red = original_screen_color.R ^ 0xff;
                                                int new_green = original_screen_color.G ^ 0xff;
                                                int new_blue = original_screen_color.B ^ 0xff;
                                                var final_color = System.Drawing.Color.FromArgb(new_red, new_green,
                                                                                                new_blue);
                                                bmp_temp.SetPixel(x, y, final_color);
                                            }
                                        }
                                    }

                                    graphics.DrawImage(bmp_temp, icon_left, icon_top);
                                }
                            }
                        }
                        else
                        {
                            throw new CaptureException("Unhandled case");
                        }
                    }
                }
                finally
                {
                    if (iconinfo.hbmColor != IntPtr.Zero)
                    {
                        Gdi32.DeleteObject(iconinfo.hbmColor);
                    }

                    if (iconinfo.hbmMask != IntPtr.Zero)
                    {
                        Gdi32.DeleteObject(iconinfo.hbmMask);
                    }
                }
            }
        }

    }
}