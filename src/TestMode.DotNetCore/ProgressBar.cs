// SampSharp
// Copyright 2018 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.Tools;
using SampSharp.GameMode.World;

namespace SampSharp.UI
{
    public enum ProgressBarDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public class ProgressBar : Disposable
    {
        private readonly PlayerTextDraw _back;
        private readonly PlayerTextDraw _fill;
        private readonly PlayerTextDraw _main;
        private float _max;
        private float _value;

        public ProgressBar(BasePlayer player, Vector2 position, float value, float width = 55.5f, float height = 3.2f, Color color = default(Color),
            float max = 100.0f, ProgressBarDirection direction = ProgressBarDirection.Right)
        {
            Position = position;
            _value = value;
            Width = width;
            Height = height;
            Color = color;
            _max = max;
            Direction = direction;

            if (player == null) throw new ArgumentNullException(nameof(player));

            switch (direction)
            {
                case ProgressBarDirection.Right:
                    _back = new PlayerTextDraw(player, position, "_")
                    {
                        UseBox = true,
                        Width = position.X + width - 4.0f,
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, height / 10),
                        BoxColor = 0x00000000 | (color & 0x000000FF)
                    };

                    _fill = new PlayerTextDraw(player, position + new Vector2(+1.2f, +2.15f), "_")
                    {
                        UseBox = true,
                        Width = position.X + width - 5.5f,
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, height / 10 - 0.35f),
                        BoxColor = (int) ((color & 0xFFFFFF00) | (0x66 & ((color & 0x000000FF) / 2)))
                    };

                    _main = new PlayerTextDraw(player, position + new Vector2(+1.2f, +2.15f), "_")
                    {
                        UseBox = true,
                        Width = CalculatePercentage(),
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, height / 10 - 0.35f),
                        BoxColor = color
                    };
                    break;
                case ProgressBarDirection.Left:
                    _back = new PlayerTextDraw(player, position, "_")
                    {
                        UseBox = true,
                        Width = position.X - width - 4.0f,
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, height / 10),
                        BoxColor = 0x00000000 | (color & 0x000000FF)
                    };

                    _fill = new PlayerTextDraw(player, position + new Vector2(-1.2f, +2.15f), "_")
                    {
                        UseBox = true,
                        Width = position.X - width - 2.5f,
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, height / 10 - 0.35f),
                        BoxColor = (int) ((color & 0xFFFFFF00) | (0x66 & ((color & 0x000000FF) / 2)))
                    };

                    _main = new PlayerTextDraw(player, position + new Vector2(-1.2f, +2.15f), "_")
                    {
                        UseBox = true,
                        Width = CalculatePercentage(),
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, height / 10 - 0.35f),
                        BoxColor = color
                    };
                    break;
                case ProgressBarDirection.Up:
                    _back = new PlayerTextDraw(player, position, "_")
                    {
                        UseBox = true,
                        Width = position.X - width - 4.0f,
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, -(height / 10 * 1.02f) - 0.35f),
                        BoxColor = 0x00000000 | (color & 0x000000FF)
                    };

                    _fill = new PlayerTextDraw(player, position + new Vector2(-1.2f, -1.0f), "_")
                    {
                        UseBox = true,
                        Width = position.X - width - 2.5f,
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, -(height / 10.0f) * 1.02f),
                        BoxColor = (int) ((color & 0xFFFFFF00) | (0x66 & ((color & 0x000000FF) / 2)))
                    };

                    _main = new PlayerTextDraw(player, position + new Vector2(-1.2f, -1.0f), "_")
                    {
                        UseBox = true,
                        Width = position.X - width - 2.5f,
                        Height = 0.0f,
                        LetterSize = new Vector2(0.0f, CalculatePercentage()),
                        BoxColor = color
                    };
                    break;

                case ProgressBarDirection.Down:
                    _back = new PlayerTextDraw(player, position, "_")
                    {
                        UseBox = true,
                        Width = position.X - width - 4.0f,
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, height / 10 - 0.35f),
                        BoxColor = 0x00000000 | (color & 0x000000FF)
                    };

                    _fill = new PlayerTextDraw(player, position + new Vector2(-1.2f, +1.0f), "_")
                    {
                        UseBox = true,
                        Width = position.X - width - 2.5f,
                        Height = 0.0f,
                        LetterSize = new Vector2(1.0f, height / 10.0f - 0.55f),
                        BoxColor = (int) ((color & 0xFFFFFF00) | (0x66 & ((color & 0x000000FF) / 2)))
                    };

                    _main = new PlayerTextDraw(player, position + new Vector2(-1.2f, +1.0f), "_")
                    {
                        UseBox = true,
                        Width = position.X - width - 2.5f,
                        Height = 0.0f,
                        LetterSize = new Vector2(0.0f, CalculatePercentage()),
                        BoxColor = color
                    };
                    break;
            }
        }

        public Vector2 Position { get; }
        public float Width { get; }
        public float Height { get; }
        public Color Color { get; }

        public float Max
        {
            get => _max;
            private set
            {
                _max = value;
                Redraw();
            }
        }

        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                Redraw();
            }
        }

        public ProgressBarDirection Direction { get; }

        private float CalculatePercentage()
        {
            switch (Direction)
            {
                case ProgressBarDirection.Right:
                    return Position.X - 3.0f + (Position.X - 2.0f + Width - Position.X) / Max * Value;
                case ProgressBarDirection.Left:
                    return Position.X - 1.0f - (Position.X + 2.0f - Width - Position.X) / Max * -Value - 4.0f;
                case ProgressBarDirection.Up:
                    return -((Height / 10.0f - 0.45f) * 1.02f / Max * Value + 0.55f);
                case ProgressBarDirection.Down:
                    return (Height / 10.0f - 0.45f) * 1.02f / Max * Value - 0.55f;
                default:
                    return 0;
            }

        }

        private void Redraw()
        {
            if (_max < 0.1f) _max = 0.1f;
            _value = _value < 0 ? 0 : (_value > Max ? Max : _value);

            _main.UseBox = _value > 0.0f;

            switch (Direction)
            {
                case ProgressBarDirection.Right:
                case ProgressBarDirection.Left:
                {
                    _main.Width = CalculatePercentage();
                }
                    break;
                case ProgressBarDirection.Up:
                case ProgressBarDirection.Down:
                {
                    _main.LetterSize = new Vector2(_main.LetterSize.X, CalculatePercentage());
                }
                    break;
            }

            Show();
        }


        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed) Hide();

            _back?.Dispose();
            _fill?.Dispose();
            _main?.Dispose();
        }

        public void Show()
        {
            AssertNotDisposed();

            _back.Show();
            _fill.Show();
            _main.Show();
        }

        public void Hide()
        {
            AssertNotDisposed();

            _back.Hide();
            _fill.Hide();
            _main.Hide();
        }
    }
}