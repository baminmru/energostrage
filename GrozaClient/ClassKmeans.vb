Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Text

Public Class ClassKmeans ' (Of MyType As {Structure})

    ' this should really adapt to the type of data in the cluster.  At the moment I'm using Decimal.
    Public Shared Sub runKmeans(ByVal X(,) As Decimal, ByVal initial_centroids(,) As Decimal, ByVal max_iters As Integer, _
                  ByRef return_Centroids(,) As Decimal, ByRef return_idx() As Integer, _
                    ByRef convergence_array() As Double, ByRef performance_error As Double)

        '        'RUNKMEANS runs the K-Means algorithm on data matrix X, where each row of X
        '        'is a single example
        '             max_iters specifies the total number of interactions 
        '        '   of K-Means to execute. plot_progress is a true/false flag that 
        '        '   indicates if the function should return an array of costs as
        '        '   learning happens. This array can be used by the caller for plotting.  runkMeans returns 
        '        '   centroids, a Kxn matrix of the computed centroids and idx, a m x 1 
        '        '   vector of centroid assignments (i.e. each entry in range [0..K-1])
        '        '


        '                ' Initialize values

        Dim K As Integer
        Dim m As Integer
        Dim n As Integer
        Dim n2 As Integer

        Get2DSize(X, m, n)
        Get2DSize(initial_centroids, K, n2)
        If K >= m Then
            Dim ex As New Exception("runKmeans needs number of clusters(" & K & ") to be less than the number of points(" & m & ")")
            Throw (ex)
        End If
        If n2 <> n Then
            Dim ex As New Exception("runKmeans needs your centroids to have the same number of columns as the dimension of your data points")
            Throw (ex)
        End If
        If K < 1 Then
            Dim ex As New Exception("runKmeans needs at least one cluster")
            Throw (ex)

        End If
        If max_iters < 1 Then
            Dim ex As New Exception("runKmeans needs max_iters (iterations) of at least one")
            Throw (ex)

        End If
        Copy2Darray(initial_centroids, return_Centroids)
        ZerosI(m, return_idx)

        '                ' Run K-Means
        Dim old_pe As Double
        For i = 0 To max_iters - 1
            ' given the centroids, find which points are closest to each centroid
            findClosestCentroids(X, return_Centroids, return_idx)
            '                            ' Given the memberships, compute new centroids
            computeCentroids(X, return_idx, K, return_Centroids)

            convergence_array(i) = computedistance(m, return_idx, X, return_Centroids)
            performance_error = convergence_array(i)
            If i = 0 Then
                old_pe = performance_error
            Else
                If old_pe = performance_error Then
                    For j = i + 1 To max_iters - 1
                        convergence_array(j) = old_pe
                    Next
                    Exit Sub
                End If
                old_pe = performance_error
            End If
        Next
    End Sub

    Shared Function computedistance(ByVal m As Integer, ByVal idx() As Integer, ByVal X(,) As Decimal, ByVal centroids(,) As Decimal) As Double
        Dim i As Integer
        Dim clust As Integer
        Dim distance As Double

        distance = 0
        For i = 0 To m - 1
            clust = idx(i)
            distance = distance + Sum1DArray(ArrayToPower(ArrayMinus(GetRowFrom2D(X, i), GetRowFrom2D(centroids, clust)), 2))
        Next
        distance = distance / m
        Return (distance)

    End Function

    '***************************
    Shared Function findClosestCentroids(ByVal X(,) As Decimal, ByVal centroids(,) As Decimal, ByRef idx() As Integer)
        'FINDCLOSESTCENTROIDS computes the centroid memberships for every example
        '   it returns the closest centroids
        '   in idx for a dataset X where each row is a single example. idx = m rows x 1 column
        '   vector of centroid assignments (i.e. each entry in range [0..K-1])
        '

        Dim K As Integer
        Dim m As Integer
        Dim n As Integer
        Dim n2 As Integer
        Dim minK As Integer
        Dim distance As Double
        Dim mindist As Double

        Get2DSize(centroids, K, n2)
        Get2DSize(X, m, n)

        ' You need to return the following variables correctly.
        ZerosI(m, idx)

        ' ====================== YOUR CODE HERE ======================
        ' Instructions: Go over every example, find its closest centroid, and store
        '               the index inside idx at the appropriate location.
        '               Concretely, idx(i) should contain the index of the centroid
        '               closest to example i. Hence, it should be a value in the 
        '               range 0..K-1
        '
        ' Note: You can use a for-loop over the examples to compute this.

        For i = 0 To m - 1
            For clust = 0 To K - 1
                distance = Sum1DArray(ArrayToPower(ArrayMinus(GetRowFrom2D(X, i), GetRowFrom2D(centroids, clust)), 2))
                If (clust = 0) Then
                    mindist = distance
                    minK = clust
                ElseIf (distance < mindist) Then
                    mindist = distance
                    minK = clust
                End If
            Next
            idx(i) = minK
        Next
        Return (idx)
    End Function
    Shared Function ArrayToPower(ByVal myArr() As Decimal, ByVal power As Integer) As Double()
        Dim retArray(myArr.GetUpperBound(0)) As Double

        ' this doesn't multiply an array by an array, it does the individual elements to a power
        For i = 0 To myArr.GetUpperBound(0)
            retArray(i) = myArr(i) ^ power
        Next
        Return retArray
    End Function
    Shared Function ArrayMinus(ByVal array1() As Decimal, ByVal array2() As Decimal) As Decimal()
        Dim arraysize As Integer = array1.Length
        Dim retArray(arraysize - 1) As Decimal
        For i = 0 To arraysize - 1
            retArray(i) = array1(i) - array2(i)
        Next
        Return retArray
    End Function

    '=======================================
    Shared Sub computeCentroids(ByVal X(,) As Decimal, ByVal idx() As Integer, ByVal K As Integer, ByRef centroids(,) As Decimal)
        'COMPUTECENTROIDS returns the new centroids by computing the means of the 
        'data points assigned to each centroid.
        '   it returns the new centroids by 
        '   computing the means of the data points assigned to each centroid. It is
        '   given a dataset X where each row is a single data point, a vector
        '   idx of centroid assignments (i.e. each entry in range [0..K-1]) for each
        '   example, and K, the number of centroids. You should return a matrix
        '   centroids, where each row of centroids is the mean of the data points
        '   assigned to it.
        '

        ' Useful variables
        Dim m As Integer
        Dim n As Integer
        Dim numbermatches As Integer

        Get2DSize(X, m, n)
        Dim matches(m - 1) As Integer

        ' You need to return the following variables correctly.
        ZerosD(K, n, centroids)

        ' ====================== YOUR CODE HERE ======================
        ' Instructions: Go over every centroid and compute mean of all points that
        '               belong to it. Concretely, the row vector centroids(i, :)
        '               should contain the mean of the data points assigned to
        '               centroid i.
        '
        ' Note: You can use a for-loop over the centroids to compute this.
        '
        For centroidindex = 0 To K - 1
            getmatch_array(idx, centroidindex, matches)

            numbermatches = Sum1DArray(matches)
            If numbermatches > 0 Then

                SetRowContents(centroids, centroidindex, DivideDecimalArraybyInteger(ArrayMult2by1(transpose2d(X), matches), numbermatches))
            End If
            ' this had an extra transpose in it, which I removed, was that OK?
        Next

    End Sub

    Shared Function Mult1Dby1D(ByVal FirstArr() As Decimal, ByVal SecondArr() As Integer) As Decimal
        Dim sum As Decimal

        sum = 0
        For i = 0 To FirstArr.GetUpperBound(0)
            sum = sum + FirstArr(i) * SecondArr(i)
        Next
        Return sum
    End Function
    Shared Sub SetRowContents(ByRef setArray(,) As Decimal, ByVal row As Integer, ByVal sourceArray() As Decimal)
        Dim numcols As Integer

        numcols = sourceArray.Length
        For i = 0 To numcols - 1
            setArray(row, i) = sourceArray(i)
        Next
    End Sub
    Shared Function GetRowFrom2D(ByVal X(,) As Decimal, ByVal rowindex As Integer) As Decimal()
        Dim numrows As Integer
        Dim numcols As Integer

        Get2DSize(X, numrows, numcols)
        Dim retarray(numcols - 1) As Decimal
        For i = 0 To numcols - 1
            retarray(i) = X(rowindex, i)
        Next
        Return retarray
    End Function
    Shared Function GetColFrom2D(ByVal X(,) As Decimal, ByVal colindex As Integer) As Decimal()
        Dim numrows As Integer
        Dim numcols As Integer

        Get2DSize(X, numrows, numcols)
        Dim retarray(numrows - 1) As Decimal
        For i = 0 To numrows - 1
            retarray(i) = X(i, colindex)
        Next
        Return retarray
    End Function
    Shared Function ArrayMult2by1(ByVal X(,) As Decimal, ByVal arr1d() As Integer) As Decimal()
        Dim m As Integer
        Dim n As Integer

        Get2DSize(X, m, n)
        Dim resultArray(m - 1) As Decimal
        For row = 0 To m - 1
            resultArray(row) = Mult1Dby1D(GetRowFrom2D(X, row), arr1d)
        Next
        Return (resultArray)
    End Function
    Shared Sub Get2DSize(ByVal X(,) As Decimal, ByRef m As Integer, ByRef n As Integer)
        m = X.GetUpperBound(0) + 1
        n = X.GetUpperBound(1) + 1
    End Sub
    Shared Function transpose2d(ByVal X(,) As Decimal) As Decimal(,)
        Dim d1 As Integer
        Dim d2 As Integer

        d1 = X.GetUpperBound(0)
        d2 = X.GetUpperBound(1)
        Dim X2(d2, d1) As Decimal
        For i = 0 To d1
            For j = 0 To d2
                X2(j, i) = X(i, j)
            Next
        Next
        Return X2
    End Function
    Shared Sub getmatch_array(ByVal idx() As Integer, ByVal centroidindex As Integer, ByRef matches() As Integer)
        '   matches = (idx==centroidindex)  ' m by 1
        Dim m As Integer
        m = idx.Length
        For i = 0 To m - 1
            matches(i) = 0
            If idx(i) = centroidindex Then
                matches(i) = 1
            End If
        Next

    End Sub
    Shared Function Sum1DArray(ByVal theArray() As Integer) As Integer
        Dim s As Integer = 0
        For i = 0 To theArray.GetUpperBound(0)
            s = s + theArray(i)
        Next
        Return (s)
    End Function
    Shared Function Sum1DArray(ByVal theArray() As Double) As Double
        Dim s As Double = 0
        For i = 0 To theArray.GetUpperBound(0)
            s = s + theArray(i)
        Next
        Return (s)
    End Function
    '  ===============================
    Public Shared Function kMeansInitCentroids(ByVal X(,) As Decimal, ByVal K As Integer) As Decimal(,)
        'KMEANSINITCENTROIDS This function initializes K centroids that are to be 
        'used in K-Means on the dataset X
        '   centroids = KMEANSINITCENTROIDS(X, K) returns K initial centroids to be
        '   used with the K-Means on the dataset X
        '
        Dim centroids(,) As Decimal
        Dim m As Integer
        Dim n As Integer
        Dim randidx() As Integer
        Dim Xrow() As Decimal

        Get2DSize(X, m, n)

        ' You should return this values correctly
        ZerosD(K, n, centroids)
        If K >= m Then
            Dim ex As New Exception("KmeansInitCentroids needs number of clusters(" & K & ") to be less than the number of rows(" & m & ")")
            Throw (ex)
        End If

        If K < 1 Then
            Dim ex As New Exception("KmeansInitCentroids  needs at least one cluster")
            Throw (ex)

        End If

        ' ====================== YOUR CODE HERE ======================
        ' Instructions: You should set centroids to randomly chosen examples from
        '               the dataset X
        '
        randidx = randperm(m)
        For j = 0 To K - 1
            Xrow = GetRowFrom2D(X, randidx(j))
            For j2 = 0 To n - 1
                centroids(j, j2) = Xrow(j2)
            Next
        Next
        Return centroids
    End Function
    Public Shared Function RandomNumber(ByVal low As Int32, ByVal high As Int32) As Integer
        Static RandomNumGen As New System.Random
        Return RandomNumGen.Next(low, high + 1)
    End Function

    Shared Sub Copy1Darray(ByVal source() As Decimal, ByRef target() As Decimal)
        If target Is Nothing Then
            ReDim target(source.GetUpperBound(0))
        End If
        For i = 0 To target.GetUpperBound(0)
            target(i) = source(i)
        Next
    End Sub
    Shared Sub Copy1Darray(ByVal source() As Integer, ByRef target() As Integer)
        If target Is Nothing Then
            ReDim target(source.GetUpperBound(0))
        End If
        For i = 0 To target.GetUpperBound(0)
            target(i) = source(i)
        Next
    End Sub
    Shared Sub Copy1Darray(ByVal source() As Double, ByRef target() As Double)
        If target Is Nothing Then
            ReDim target(source.GetUpperBound(0))
        End If
        For i = 0 To target.GetUpperBound(0)
            target(i) = source(i)
        Next
    End Sub
    Shared Sub Copy2Darray(ByVal source(,) As Decimal, ByRef target(,) As Decimal)
        If target Is Nothing Then
            ReDim target(source.GetUpperBound(0), source.GetUpperBound(1))
        End If
        For i = 0 To target.GetUpperBound(0)
            For j = 0 To target.GetUpperBound(1)
                target(i, j) = source(i, j)
            Next
        Next
    End Sub
    Shared Function ZerosD(ByVal m As Integer, ByVal n As Integer, ByRef localarray(,) As Decimal)
        If localarray Is Nothing Then
            ReDim localarray(m - 1, n - 1)
        End If

        ' note that you are passed a numrows and numcols, but your array is zero based
        For i = 0 To m - 1
            For j = 0 To n - 1
                localarray(i, j) = 0
            Next
        Next
        Return localarray
    End Function
    Shared Function ZerosI(ByVal numrows As Integer, ByRef retArray() As Integer)
        If retArray Is Nothing Then
            ReDim retArray(numrows - 1)
        End If
        For i = 0 To numrows - 1
            retArray(i) = 0
        Next
        Return retArray
    End Function
    Shared Function ZerosD(ByVal numrows As Integer, ByRef retArray() As Decimal)
        If retArray Is Nothing Then
            ReDim retArray(numrows - 1)
        End If
        For i = 0 To numrows - 1
            retArray(i) = 0
        Next
        Return retArray
    End Function
    Shared Function ZerosI(ByVal m As Integer, ByVal n As Integer, ByRef localArray(,) As Integer)
        If localArray Is Nothing Then
            ReDim localArray(m - 1, n - 1)
        End If

        ' note that you are passed a numrows and numcols, but your array is zero based
        For i = 0 To m - 1
            For j = 0 To n - 1
                localArray(i, j) = 0
            Next
        Next
        Return localArray
    End Function
    Shared Function DivideDecimalArraybyInteger(ByVal X(,) As Decimal, ByVal divisor As Integer) As Decimal(,)
        Dim m As Integer
        Dim n As Integer

        Get2DSize(X, m, n)
        Dim retX(m - 1, n - 1) As Decimal
        For i = 0 To m - 1
            For j = 0 To n - 1
                If divisor = 0 Then
                    retX(i, j) = X(i, j)
                Else
                    retX(i, j) = X(i, j) / divisor
                End If

            Next
        Next
        Return retX
    End Function
    Shared Function DivideDecimalArraybyinteger(ByVal X() As Decimal, ByVal divisor As Integer) As Decimal()

        Dim m As Integer
        m = X.Length
        Dim retX(m - 1) As Decimal
        For i = 0 To m - 1
            If divisor = 0 Then
                retX(i) = X(i)
            Else
                retX(i) = X(i) / divisor
            End If

        Next
        Return retX
    End Function

    Shared Function randperm(ByVal m As Integer) As Integer()
        'Return a row vector containing a random permutation of 0 to m0. 

        Dim upperbound As Integer
        upperbound = m - 1
        Dim retArray(upperbound) As Integer
        Dim max As Integer
        Dim index As Integer
        Dim index2 As Integer
        Dim occupiedarray(upperbound) As Boolean

        For i = 0 To upperbound
            occupiedarray(i) = False
        Next
        For i = 0 To upperbound
            max = upperbound - i
            index = RandomNumber(0, max)
            index2 = translateIndex(index, occupiedarray)
            occupiedarray(index2) = True
            retArray(i) = index2
        Next
        Return retArray
    End Function
    Shared Function translateIndex(ByVal index As Integer, ByRef occupiedArray() As Boolean) As Integer
        For oi = 0 To occupiedArray.GetUpperBound(0)
            If occupiedArray(oi) Then
                Continue For
            End If
            If index = 0 Then
                Return (oi)
            End If
            index = index - 1
        Next
        Return (-1) ' should never get here.
    End Function
    Shared Function display_array(ByVal strName As String, ByVal arr() As Integer) As String
        Dim sb As New StringBuilder(strName & ": ")
        For i = 0 To arr.GetUpperBound(0)
            If i > 0 Then
                sb.Append(",")
            End If
            sb.Append(arr(i))
        Next
        Return sb.ToString
    End Function
End Class

