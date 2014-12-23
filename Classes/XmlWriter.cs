#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Windows.Forms;

using System.IO;
using XNA_Map_Editor.Helpers;
#endregion

namespace XNA_Map_Editor.Classes
{
    class XmlMapWriter
    {
        #region Class Fields

        MainForm        parent_form;

        XmlTextWriter   xml_text_writer;
        MemoryStream    memory_stream;
        SaveFileDialog  save_xml_dialog;

        #endregion

        public XmlMapWriter(MainForm ParentForm)
        {
            parent_form                         = ParentForm;
            parent_form.rch_txtbox.BackColor    = System.Drawing.Color.White;
            parent_form.rch_txtbox.ForeColor    = System.Drawing.Color.Green;

            save_xml_dialog                     = new SaveFileDialog();
            save_xml_dialog.InitialDirectory    = Environment.CurrentDirectory + @"\Maps";
            save_xml_dialog.Filter              = "XML File (*.xml) | *.xml";
            save_xml_dialog.Title               = "Export to XML";
        }

        #region Public Methods

        // Export to XML file
        public void Export()
        {
            // Open save dialog            
            DialogResult saved_result       = save_xml_dialog.ShowDialog();

            if (saved_result == DialogResult.OK)
            {
                // Save XML file, encoding null == UTF-8 which is what we use for creating xml
                XmlTextWriter xml_to_file = new XmlTextWriter(save_xml_dialog.FileName, null);

                this.CreateXmlDocument(xml_to_file, false);

                //MessageBox.Show("Export Completed!", "XML Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        internal void Update()
        {
            parent_form.rch_txtbox.Text = "";
            //if (memory_stream == null)
            {
                this.CreateXmlDocument();

                byte[] byte_array = new byte[memory_stream.Length];
                memory_stream.Read(byte_array, 0, (int)memory_stream.Length);

                String aux_string = Encoding.UTF8.GetString(byte_array);
                String[] lines    = aux_string.Split(Convert.ToChar("\n"));

                // Format and save the text to the richtextbox control
                FormatXmlText(lines);
            }

            memory_stream.Close();
        }

        internal void SaveMapXml(string FileName)
        {
            //if (memory_stream == null)
            {
                this.CreateXmlDocument();

                byte[] byte_array = new byte[memory_stream.Length];
                memory_stream.Read(byte_array, 0, (int)memory_stream.Length);

                String aux_string = Encoding.UTF8.GetString(byte_array);
                String[] lines = aux_string.Split(Convert.ToChar("\n"));

                // Format and save the text
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(getXmlText(lines));

                using (StreamWriter outfile = new StreamWriter(FileName))
                {
                    outfile.Write(sb.ToString());
                }


            }

            memory_stream.Close();
        }

        #endregion

        #region Private Methods

        private void CreateXmlDocument()
        {
            CreateXmlDocument(this.xml_text_writer, true);
        }

        private void CreateXmlDocument(XmlTextWriter Writer, Boolean UsingStream)
        {
            if (UsingStream)
            {
                memory_stream = new MemoryStream();
                xml_text_writer = new XmlTextWriter(memory_stream, Encoding.UTF8);
            }
            else
            {
                xml_text_writer = Writer;
            }

            xml_text_writer.Formatting  = Formatting.Indented;

            xml_text_writer.WriteStartDocument();

            xml_text_writer.WriteStartElement("XnaContent");
            xml_text_writer.WriteStartElement("Asset");
            xml_text_writer.WriteStartAttribute("Type");
            xml_text_writer.WriteString("RolePlayingGameData.Map");
            xml_text_writer.WriteEndAttribute();

            {
                xml_text_writer.WriteElementString("Name", GLB_Data.MapName);
                xml_text_writer.WriteElementString("MapDimensions", GLB_Data.MapSize.Width.ToString() + " " + GLB_Data.MapSize.Height.ToString());
                xml_text_writer.WriteElementString("TileSize", GLB_Data.MapSize.TileSize.ToString() + " " + GLB_Data.MapSize.TileSize.ToString());
                xml_text_writer.WriteElementString("SpawnMapPosition", "10 10");
                

               // Texture
               if (GLB_Data.TilesTexture == null)
               {
                    xml_text_writer.WriteElementString("TextureName", "null");
                    //xml_text_writer.WriteElementString("Width", "null");
                    //xml_text_writer.WriteElementString("Height", "null");
                }
                else
                {
                    string texName = GLB_Data.TextureFileName;
                    xml_text_writer.WriteElementString("TextureName", texName);
                    //xml_text_writer.WriteElementString("Width", GLB_Data.TilesTexture.Width.ToString());
                    //xml_text_writer.WriteElementString("Height", GLB_Data.TilesTexture.Height.ToString());
                }


               xml_text_writer.WriteElementString("CombatTextureName", "CombatBkgdVillage");
               xml_text_writer.WriteElementString("MusicCueName", "");
               xml_text_writer.WriteElementString("CombatMusicCueName", "BattleTheme");

                /*
                xml_text_writer.WriteStartElement("TERRAINS");
                {
                    xml_text_writer.WriteElementString("TotalTerrains", GLB_Data.TerrainList.Count.ToString());

                    foreach (TerrainType t in GLB_Data.TerrainList)
                    {
                        xml_text_writer.WriteStartElement("TerrainInfo");

                        xml_text_writer.WriteElementString("Id", t.Id.ToString());
                        xml_text_writer.WriteElementString("Name", t.Name);
                        xml_text_writer.WriteElementString("Speed", t.TerrainSpeed.ToString());

                        xml_text_writer.WriteEndElement(); // TerrainInfo
                    }
                }
                xml_text_writer.WriteEndElement(); // TERRAIN
                */

                //xml_text_writer.WriteStartElement("LAYOUT");
                {
                    for (int id_z = 0; id_z < GLB_Data.MapSize.Depth; id_z++)
                    {
                        string layerName = "newLayer";

                        if (id_z == 0)
                        {
                            layerName = "BaseLayer";
                        }

                        if (id_z == 1)
                        {
                            layerName = "FringeLayer";
                        }

                        if (id_z == 2)
                        {
                            layerName = "ObjectLayer";
                        }

                        xml_text_writer.WriteStartElement(layerName);
                        xml_text_writer.WriteString(Environment.NewLine);
                        //xml_text_writer.WriteValue(id_z);
                        {


                            for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                            {
                                int[] aux_tile_row = new int[GLB_Data.MapSize.Width];

                                for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                                {
                                    aux_tile_row[id_x] = GLB_Data.TileMap[id_z, id_x, id_y].id;
                                }

                                // write row
                                StringBuilder aux_string_builder = new StringBuilder();

                                for (int n = 0; n < aux_tile_row.GetLength(0); n++)
                                {
                                    if (n == aux_tile_row.GetLength(0) - 1)
                                    {
                                        aux_string_builder.Append(Convert.ToString(aux_tile_row[n]));
                                    }
                                    else
                                    {
                                        aux_string_builder.Append(Convert.ToString(aux_tile_row[n]) + " ");
                                    }
                                }

                                xml_text_writer.WriteString(aux_string_builder.ToString() + Environment.NewLine);

                            }// for (layers);
                        }
                        xml_text_writer.WriteEndElement();
                    }

                    xml_text_writer.WriteStartElement("CollisionLayer");
                    xml_text_writer.WriteString(Environment.NewLine);

                    // walk layer
                    for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                    {
                        int[] aux_tile_row = new int[GLB_Data.MapSize.Width];

                        for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                        {
                            aux_tile_row[id_x] = Convert.ToInt32(GLB_Data.TileMap[GLB_Data.TileMap.GetLength(0) - 1, id_x, id_y].walkable);
                        }

                        // write row
                        StringBuilder aux_string_builder = new StringBuilder();

                        for (int n = 0; n < aux_tile_row.GetLength(0); n++)
                        {
                            //switch the ones and zeroes
                            if (aux_tile_row[n] == 1)
                                aux_tile_row[n] = 0;
                            else if(aux_tile_row[n] == 0)
                                aux_tile_row[n] = 1;


                            if (n == aux_tile_row.GetLength(0) - 1)
                            {
                                aux_string_builder.Append(Convert.ToString(aux_tile_row[n]));
                            }
                            else
                            {
                                aux_string_builder.Append(Convert.ToString(aux_tile_row[n]) + " ");
                            }
                        }

                        xml_text_writer.WriteString(aux_string_builder.ToString() + Environment.NewLine);
                    }
                }
                xml_text_writer.WriteEndElement();// CollisionLayer;

                /*
                xml_text_writer.WriteStartElement("TerrainLayer");
                {
                    // walk layer
                    for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                    {
                        int[] aux_tile_row = new int[GLB_Data.MapSize.Width];

                        for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                        {
                            aux_tile_row[id_x] = GLB_Data.TerrainLayout[id_x, id_y];
                        }

                        // write row
                        StringBuilder aux_string_builder = new StringBuilder();

                        for (int n = 0; n < aux_tile_row.GetLength(0); n++)
                        {
                            if (n == aux_tile_row.GetLength(0) - 1)
                            {
                                aux_string_builder.Append(Convert.ToString(aux_tile_row[n]));
                            }
                            else
                            {
                                aux_string_builder.Append(Convert.ToString(aux_tile_row[n]) + " ");
                            }
                        }

                        xml_text_writer.WriteString(aux_string_builder.ToString() + Environment.NewLine);
                    }
                }
                xml_text_writer.WriteEndElement(); // TerrainLayer
            */
            }


            //write portal entries
            xml_text_writer.WriteStartElement("Portals");

            for (int i = 0; i < GLB_Data.destinations.Count; i++)
            {
                xml_text_writer.WriteStartElement("Item");
                xml_text_writer.WriteElementString("Name", GLB_Data.destinations[i].name);
                xml_text_writer.WriteElementString("LandingMapPosition", GLB_Data.destinations[i].x.ToString() + " " + GLB_Data.destinations[i].y.ToString());
                xml_text_writer.WriteElementString("DestinationMapContentName", GLB_Data.destinations[i].destinationMap);
                xml_text_writer.WriteElementString("DestinationMapPortalName", GLB_Data.destinations[i].destinationPortal.name);
                xml_text_writer.WriteEndElement();
            }

            xml_text_writer.WriteEndElement();



            //write portals
            xml_text_writer.WriteStartElement("PortalEntries");

            for (int i = 0; i < GLB_Data.portals.Count; i++)
            {
                xml_text_writer.WriteStartElement("Item");
                xml_text_writer.WriteElementString("ContentName", GLB_Data.portals[i].name);
                xml_text_writer.WriteElementString("MapPosition", GLB_Data.portals[i].x.ToString() + " " + GLB_Data.portals[i].y.ToString());
                xml_text_writer.WriteEndElement();
            }

            xml_text_writer.WriteEndElement();



            xml_text_writer.WriteStartElement("ChestEntries");

            foreach(Chest chest in GLB_Data.chests)
            {
                xml_text_writer.WriteStartElement("Item");
                xml_text_writer.WriteElementString("ContentName", chest.name);
                xml_text_writer.WriteElementString("MapPosition", chest.x + " " + chest.y);
                xml_text_writer.WriteEndElement();
            }

            xml_text_writer.WriteEndElement();


            
            xml_text_writer.WriteStartElement("FixedCombatEntries");

            foreach(FixedCombatNPC combatNPC in GLB_Data.fixedCombatNPCs)
            {
                xml_text_writer.WriteStartElement("Item");
                xml_text_writer.WriteElementString("ContentName", combatNPC.name);
                xml_text_writer.WriteElementString("MapPosition", combatNPC.x + " " + combatNPC.y);
                xml_text_writer.WriteElementString("Direction", combatNPC.direction);
                xml_text_writer.WriteEndElement();
            }

            xml_text_writer.WriteEndElement();



            xml_text_writer.WriteStartElement("lightsources");

            xml_text_writer.WriteString(Environment.NewLine + "0,0, 300, 1.5, 1, 0.001, 1, 1.1, 00000000, 00000000, 00000000, 00000000, 9, -180, 181,player" + Environment.NewLine);

            foreach (FixedCombatNPC combatNPC in GLB_Data.fixedCombatNPCs)
            {
                xml_text_writer.WriteString((combatNPC.x * 64).ToString() + ", " + (combatNPC.y * 64).ToString() + ", 300, 1.5, 1, 0.001, 1, 1.1, 00000000, 00000000, 00000000, 00000000, 9, -180, 181," + Environment.NewLine);

            }

            xml_text_writer.WriteEndElement();



            xml_text_writer.WriteStartElement("RandomCombat");

            xml_text_writer.WriteElementString("CombatProbability", "0");
            xml_text_writer.WriteElementString("FleeProbability", "50");

            xml_text_writer.WriteStartElement("MonsterCountRange");
            xml_text_writer.WriteElementString("Minimum", "1");
            xml_text_writer.WriteElementString("Maximum", "3");
            xml_text_writer.WriteEndElement();

            xml_text_writer.WriteStartElement("Entries");
            xml_text_writer.WriteStartElement("Item");
            xml_text_writer.WriteElementString("ContentName", "GoblinGrunt");
            xml_text_writer.WriteElementString("Count", "1");
            xml_text_writer.WriteElementString("Weight", "100");
            xml_text_writer.WriteEndElement();
            xml_text_writer.WriteEndElement();

            xml_text_writer.WriteEndElement(); //random combat



            xml_text_writer.WriteStartElement("QuestNpcEntries");

            foreach (NPC npc in GLB_Data.npcs)
            {
                xml_text_writer.WriteStartElement("Item");
                xml_text_writer.WriteElementString("ContentName", npc.name);
                xml_text_writer.WriteElementString("MapPosition", (npc.x+1) + " " + (npc.y+1));
                xml_text_writer.WriteEndElement();
            }

            xml_text_writer.WriteEndElement();


            xml_text_writer.WriteElementString("PlayerNpcEntries", null);
            xml_text_writer.WriteElementString("InnEntries", null);
            xml_text_writer.WriteElementString("StoreEntries", null);



            xml_text_writer.WriteStartElement("BlockEntries");

            foreach (Block block in GLB_Data.blocks)
            {
                xml_text_writer.WriteStartElement("Item");
                xml_text_writer.WriteElementString("ContentName", "AlwaysPush");// block.name);
                xml_text_writer.WriteElementString("MapPosition", block.x + " " + block.y);
                xml_text_writer.WriteEndElement();
            }

            xml_text_writer.WriteEndElement();


            xml_text_writer.WriteStartElement("SwitchEntries");

            foreach (Switch Switch in GLB_Data.switches)
            {
                xml_text_writer.WriteStartElement("Item");
                xml_text_writer.WriteElementString("ContentName", Switch.name);
                xml_text_writer.WriteElementString("MapPosition", Switch.x + " " + Switch.y);
                xml_text_writer.WriteEndElement();
            }

            xml_text_writer.WriteEndElement();



            xml_text_writer.WriteEndElement();// Asset

            xml_text_writer.WriteFullEndElement();

            if (UsingStream)
            {
                xml_text_writer.Flush();
                // Position to begining of stream 
                memory_stream.Position = 0;
            }
            else
            {
                xml_text_writer.WriteEndDocument();
                xml_text_writer.Close();
            }
        }

        private void FormatXmlText(string[] XmlText)
        {
            int line_count = 0;

            // dynamic line numbering
            String buffer = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";

            bool skipFirstLine = true;

            foreach (String line in XmlText)
            {
                String numbering = line_count.ToString();

                for (int x = 0; x < XmlText.GetLength(0).ToString().Length; x++)
                {
                    numbering += " ";
                }

                //buffer += numbering + " " + line;

                //first like is wack and indents weirdly which screws up the xml.  
                //instead we init the buffer to the first line and skip writing the first line
                if (skipFirstLine)
                {
                    skipFirstLine = false;
                }
                else
                {
                    buffer += line;
                }

                line_count++;
            }

            parent_form.rch_txtbox.Text = buffer;
        }

        private string getXmlText(string[] XmlText)
        {
            int line_count = 0;

            // dynamic line numbering
            String buffer = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";

            bool skipFirstLine = true;

            foreach (String line in XmlText)
            {
                String numbering = line_count.ToString();

                for (int x = 0; x < XmlText.GetLength(0).ToString().Length; x++)
                {
                    numbering += " ";
                }

                //buffer += numbering + " " + line;

                //first like is wack and indents weirdly which screws up the xml.  
                //instead we init the buffer to the first line and skip writing the first line
                if (skipFirstLine)
                {
                    skipFirstLine = false;
                }
                else
                {
                    buffer += line;
                }

                line_count++;
            }

            return buffer;
        }

        #endregion
    }
}
