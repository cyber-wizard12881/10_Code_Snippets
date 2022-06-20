# 8. For any array with random integers (+ve, -ve or zeroes) find the contiguous ones that contribute
#    to the minimum sum?
# Function to find out the minimum contiguous sum in an array!!!!!
# There will be a global min sum & a local min sum involved in this algorithm
def min_contiguous_sum(arr: []):
    # initialize global min sum to first element of the array
    min_sum = arr[0]
    # initialize local min sum to first element of the array
    min_sum_current = arr[0]
    j = 0
    k = 0
    # iterate thru' rest of the array
    for i in range(1, len(arr)):
        # if current element contributes to lowering the sum, then pick it!
        if arr[i] < min_sum_current + arr[i]:
            j = i
        # update the local min sum
        min_sum_current = min(arr[i], min_sum_current + arr[i])
        # if local is less than global min sum, update global min sum
        if min_sum > min_sum_current:
            k = i
        # updating global min sum
        min_sum = min(min_sum, min_sum_current)
    if j > k:
        return [min(arr)]  # only one element in this case, return it (smallest one)
    return arr[j:k + 1]  # return the contiguous elements for the min. sum.


# The Main Driver Program!!!!
if __name__ == '__main__':
    inputs = [0, 1, 2, 3, -4, -5, 0, -6, 7, 8, 9, -10, 0, -11, 12, -13, -14, -15, 16, 0]
    print(f"For the input array {inputs} .... ")
    print(f"Minimum contiguous sum is {sum(min_contiguous_sum(inputs))} with the elements as "
          f"{min_contiguous_sum(inputs)} .... ")
