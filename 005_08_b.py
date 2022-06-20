# 8. For a random array of integers (-ve, +ve, zeroes) find out the contiguous ones that
#    contribute to the minimum product?

from functools import reduce
from operator import mul

# The Idea is to be Greedy Here!!
# Take the entire array, and work to converge towards the center from the left & right ends!
# move the left or the right pointer, one at a time .... till you get the minimum product!

# Below is a Function to find out the minimum contiguous product in an array (without zeroes)!!!!!
def min_contiguous_product_without_zeroes(arr: []):
    if len(arr) == 0: # base case .. empty array
        return 0
    negatives = 0
    negative_map = dict()
    min_product = 1 # the multiplicative identity

    # build a map to count whether there are any -ves or even or odd number of them.
    for i in range(0, len(arr)):
        if arr[i] < 0:
            negative_map[i] = arr[i]
            negatives += 1
        min_product *= arr[i]

    # if no -ves, then the min. element in the array is the answer!
    if negatives == 0:
        return [min(arr)]

    # if odd number of -ves, then the entire array as product of all will be -ve!
    if negatives % 2 != 0:
        return arr

    # if -ves are even, then narrow down the array from it's extremeties!
    # Basically move the left pointer one step right
    # Move the the right pointer one step left
    # Compare the current array with the above 2 cases!
    if negatives % 2 == 0:
        negative_list = list(negative_map.keys())
        if len(negative_list) > 0:
            right_index = negative_list[-1]
            left_index = negative_list[0]
            left_chunk = arr[:right_index - 1]
            min_product_left = reduce(mul, left_chunk, 1)
            right_chunk = arr[left_index + 1:]
            min_product_right = reduce(mul, right_chunk, 1)
            if min_product_left < min_product_right:
                return left_chunk
            else:
                return right_chunk
    return 0


# Below is the Function to find out the minimum contiguous product in an array (with zeroes)!!!!!
# Note that when there are zeroes in the array, the output of the previous function will become 0!
# To handle that, we create partitions of non-zero elements by treating the zeroes as the delimiters!
def min_contiguous_product(arr: []):
    chunk_map = dict()
    j = 0
    k = 0
    # create chunks or partitions of contiguous elems where zeroes serve as the delims or the barriers!
    for i in range(0, len(arr)):
        # if 1st elem is 0, take all following it into one partition
        if arr[i] == 0:
            chunk_map[j] = arr[k:i]
            k = i + 1
            j += 1
        # if last elem is 0; take all preceding it into one partition
        elif i == len(arr) - 1:
            chunk_map[j] = arr[k:i + 1]

    # take first elem as min product
    min_product = arr[0]

    # if there are no zeroes
    if len(list(chunk_map.keys())) == 0:
        chunk_map[0] = arr

    chunk_keys = list(chunk_map.keys())
    min_prod_elems = []

    # iterate thru' each chunk created above, with elems non-zeroes in each chunk!
    for k in range(0, len(chunk_keys)):
        # if there are partitions...
        if len(chunk_map[k]) > 0:
            # compute product of the partitions! set to min product seen so far ... computed locally!
            # this will call the prev. function (the one without zeroes)
            min_prod = reduce(mul, min_contiguous_product_without_zeroes(chunk_map[k]), 1)
            # if the local min prod is less than the global min prod, then update the global one as the local one!
            # this will call the prev. function (the one without zeroes)
            if min_prod < min_product:
                min_prod_elems = min_contiguous_product_without_zeroes(chunk_map[k])
            # take the lesser of the global or the local min prod & update the global one as the min prod!
            min_product = min(min_product, min_prod)
    # if the entire chunk contributed to min prod, return it!
    if not min_prod_elems:
        return [min_product]
    # if not, then return the subset of contiguous elems within that partition as the min prod!
    return min_prod_elems


# The Main Driver Program!!!!
if __name__ == '__main__':
    inputs = [0, 1, 2, 3, -4, -5, 0, -6, 7, 8, 9, -10, 0, -11, 12, -13, -14, -15, 16, 0]
    print(f"For the input array {inputs} .... ")
    print(f"Minimum contiguous product is {reduce(mul, min_contiguous_product(inputs), 1)} with the elements as "
          f"{min_contiguous_product(inputs)} .... ")
