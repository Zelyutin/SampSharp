﻿// SampSharp
// Copyright (C) 2015 Tim Potze
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org>

using SampSharp.GameMode.World;

namespace SampSharp.GameMode.Events
{
    /// <summary>
    ///     Provides data for the <see cref="BaseMode.PlayerObjectMoved" /> event.
    /// </summary>
    public class PlayerObjectEventArgs : PlayerEventArgs
    {
        public PlayerObjectEventArgs(int playerid, int objectid) : base(playerid)
        {
            ObjectId = objectid;
        }

        public int ObjectId { get; private set; }

        public PlayerObject PlayerObject
        {
            get { return ObjectId == PlayerObject.InvalidId ? null : PlayerObject.FindOrCreate(Player, ObjectId); }
        }
    }
}