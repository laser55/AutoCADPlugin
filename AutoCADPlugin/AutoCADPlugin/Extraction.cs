using System.Collections.Generic;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
namespace AutoCADPlugin
{
    public class Extraction
    {
        public static List<BlockInfo> Extract()
        {
            try
            {
                List<BlockInfo> blockInfoList = new List<BlockInfo>();

                DocumentCollection autocadDocumentManager = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;
                Document autocadDocument = autocadDocumentManager.MdiActiveDocument;
                Database autocadDocumentDatabase = autocadDocument.Database;
                DocumentLock acDocLock = autocadDocument.LockDocument();
                using (acDocLock)
                {
                    using (Transaction acTrans = autocadDocumentDatabase.TransactionManager.StartTransaction())
                    {
                        BlockTable acBlkTbl;
                        acBlkTbl = acTrans.GetObject(autocadDocumentDatabase.BlockTableId, OpenMode.ForWrite) as BlockTable;
                        BlockTableRecord acBlkTblRec;
                        acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        foreach (ObjectId acObjId in acBlkTblRec)
                        {
                            if (acObjId.ObjectClass.DxfName == "INSERT")
                            {
                                BlockInfo blockInfo = new BlockInfo();
                                BlockReference entInsert = (BlockReference)(acTrans.GetObject(acObjId, OpenMode.ForWrite));
                                BlockTableRecord entInsertBlockTableRecord = (BlockTableRecord)entInsert.DynamicBlockTableRecord.GetObject(OpenMode.ForWrite);

                                foreach (ObjectId attId in entInsert.AttributeCollection)
                                {
                                    AttributeReference attRef = (AttributeReference)acTrans.GetObject(attId, OpenMode.ForRead, false, true);
                                    blockInfo.BlockAttributes.Add(attRef.Tag, attRef.TextString);
                                }
                                foreach (ObjectId objectID in entInsertBlockTableRecord)
                                {
                                    DBObject obj = (Entity)acTrans.GetObject(objectID, OpenMode.ForWrite);
                                    if (obj is AttributeDefinition)
                                    {
                                        AttributeDefinition attDef = obj as AttributeDefinition;
                                        if (attDef.Constant)
                                        {
                                            blockInfo.BlockAttributes.Add(attDef.Tag, attDef.TextString);
                                        }
                                    }
                                }

                                blockInfoList.Add(blockInfo);
                            }
                        }
                    }
                }
                return blockInfoList;
            }
            catch
            {
                System.Windows.MessageBox.Show("Extraction Failed");
                return null;
            }
        }
    }
}
