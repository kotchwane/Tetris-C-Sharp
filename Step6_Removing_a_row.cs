using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Source;



namespace Test

{

    [TestClass]

    public class Step6_RemovingRowsTest

    {

        Board board;

        Tetromino piece;



        [TestInitialize]

        public void SetUp() {

            board = new Board(6, 8);

            piece = new Tetromino(

                ".X.\n" +

                ".X.\n" +

                ".X.\n"

            );

        }



        void DropAndPushDown() {

            board.Drop(piece);

            while (board.IsFallingBlock()) {

                board.Tick();

            }

        }



        #region when_one_row_becomes_full



        [TestMethod]

        public void the_row_is_removed() {

            // arrange

            board.FromString(

                "........\n" +

                "........\n" +

                "........\n" +

                "AA.A.AAA\n" +

                "BBBB.BBB\n" +

                "CCCC.C.C\n"

            );



            // act

            DropAndPushDown();



            // assert

            Assert.IsFalse(board.ToString().Contains("B"));

        }



        [TestMethod]

        public void the_other_rows_move_down_to_fill_the_empty_space() {

            // arrange

            board.FromString(

                "........\n" +

                "........\n" +

                "........\n" +

                "AA.A.AAA\n" +

                "BBBB.BBB\n" +

                "CCCC.C.C\n"

            );



            // act

            DropAndPushDown();



            // assert

            Assert.AreEqual(board.ToString(),

                "........\n" +

                "........\n" +

                "........\n" +

                "........\n" +

                "AA.AXAAA\n" +

                "CCCCXC.C\n"

            );

        }



        #endregion



        #region when_many_rows_become_full_at_the_same_time



        [TestMethod]

        public void the_rows_are_removed() {

            // arrange

            board.FromString(

                "........\n" +

                "........\n" +

                "........\n" +

                "AAAA.AAA\n" +

                "BBBB..BB\n" +

                "CCCC.CCC\n"

            );



            // act

            DropAndPushDown();



            // assert

            Assert.IsFalse(board.ToString().Contains("A"));

            Assert.IsFalse(board.ToString().Contains("C"));

        }



        [TestMethod]

        public void the_removed_rows_are_filled() {

            // arrange

            board.FromString(

                "........\n" +

                "........\n" +

                "........\n" +

                "AAAA.AAA\n" +

                "BBBB..BB\n" +

                "CCCC.CCC\n"

            );



            // act

            DropAndPushDown();



            // assert

            Assert.AreEqual(board.ToString(),

                "........\n" +

                "........\n" +

                "........\n" +

                "........\n" +

                "........\n" +

                "BBBBX.BB\n"

            );

        }



        #endregion

    }

}
